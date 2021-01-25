using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Classes;
using Moq;
using Moq.Protected;
using TaxJar;
using TaxJar.Exceptions;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarCalculatorTest
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public TaxJarCalculatorTest()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        }
        
        [Fact]
        public async Task GetTaxForOrder_Error()
        {
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                });

            TaxJarCalculator taxJarCalculator =
                new TaxJarCalculator(new HttpClient(_mockHttpMessageHandler.Object), "");

            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "US",
                "92093",
                "CA",
                "La Jolla",
                "9500 Gilman Drive"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "90002",
                "CA",
                "Los Angeles",
                "1335 E 103rd St"
            );

            var order = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), 15m, 1.5m,
                new List<LineItem>());

            await Assert.ThrowsAsync<TaxJarTaxesForOrderException>(() => taxJarCalculator.GetTaxForOrderAsync(order));
        }

        [Fact]
        public async Task GetTaxForOrder_Success()
        {

            var response = @"{'tax':{'rate':1, 'taxable_amount': 2}}";
            
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(response, Encoding.UTF8, "application/json")
                });

            TaxJarCalculator taxJarCalculator =
                new TaxJarCalculator(new HttpClient(_mockHttpMessageHandler.Object), "");

            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "US",
                "92093",
                "CA",
                "La Jolla",
                "9500 Gilman Drive"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "90002",
                "CA",
                "Los Angeles",
                "1335 E 103rd St"
            );

            var order = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), 15m, 1.5m,
                new List<LineItem>());
            var tax = await taxJarCalculator.GetTaxForOrderAsync(order);
            
            Assert.Equal(1m, tax.Rate);
            Assert.Equal(2m, tax.TaxableAmount);
        }
        
    }
}
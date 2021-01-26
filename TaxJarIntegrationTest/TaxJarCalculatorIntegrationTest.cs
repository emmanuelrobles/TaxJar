using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Classes;
using TaxJar;
using TaxJar.Classes;
using TaxJar.Exceptions;
using Xunit;

namespace TaxJarIntegrationTest
{
    public class TaxJarCalculatorIntegrationTest
    {
        private readonly TaxJarCalculator _taxJarCalculator;

        public TaxJarCalculatorIntegrationTest()
        {
            
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.taxjar.com");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API Goes Here");

            ITaxJarRateLocationFactory rateLocationFactory = new TaxJarRateLocationHttpFactory(client);

            _taxJarCalculator = new TaxJarCalculator(client, rateLocationFactory);
        }

        [Fact]
        public async Task GetTaxForOrder_Success()
        {

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
            var tax = await _taxJarCalculator.GetTaxForOrderAsync(order);

            Assert.Equal(0.095m, tax.Rate);
            Assert.Equal(15m, tax.TaxableAmount);
        }
    }
}
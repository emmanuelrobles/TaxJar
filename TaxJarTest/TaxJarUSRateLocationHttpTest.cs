using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Core.Classes;
using Moq;
using Moq.Protected;
using TaxJar;
using TaxJar.Classes;
using TaxJar.Exceptions;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarUSRateLocationHttpTest
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _client;
        
        public TaxJarUSRateLocationHttpTest()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _client = new HttpClient(_mockHttpMessageHandler.Object);
            _client.BaseAddress = new Uri("https://api.taxjar.com/");
        }

        [Fact]
        public async Task GetRates_Error()
        {
            var address = new Address(
                Guid.NewGuid(), 
                "US",
                "12345",
                "FL",
                "City",
                "street"
            );
            
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                });
            
            var rateLocation = new TaxJarUsRateLocation(address, _client);

            await Assert.ThrowsAsync<TaxJarRatesLocationException>(() => rateLocation.GetTaxRateAsync());
        }
     
        [Fact]
        public async Task GetRate_Success()
        {
            var address = new Address(
                Guid.NewGuid(), 
                "US",
                "12345",
                "FL",
                "City",
                "street"
            );
            
            _mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(@"{'rate':{'combined_rate':'1'}}")
                });
            
            var rateLocation = new TaxJarUsRateLocation(address, _client);
            var rate = await rateLocation.GetTaxRateAsync();
            Assert.Equal(1m,rate.Rate);
        }
        
    }
}
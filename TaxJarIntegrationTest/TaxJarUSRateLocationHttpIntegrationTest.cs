using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Core.Classes;
using TaxJar.Classes;
using TaxJar.Exceptions;
using Xunit;

namespace TaxJarIntegrationTest
{
    public class TaxJarUSRateLocationHttpIntegrationTest
    {
        private readonly HttpClient _client;

        public TaxJarUSRateLocationHttpIntegrationTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.taxjar.com/");
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "Api Goes here");
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

            var rateLocation = new TaxJarUsRateLocation(address, _client);
            var rate = await rateLocation.GetTaxRateAsync();
            Assert.Equal(0.06m, rate.Rate);
        }
    }
}
using System;
using System.Net.Http;
using Core.Classes;
using TaxJar.Classes;
using TaxJar.Exceptions;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarRateLocationHttpFactoryTest
    {

        private readonly ITaxJarRateLocationFactory _rateLocationFactory;

        public TaxJarRateLocationHttpFactoryTest()
        {
            _rateLocationFactory = new TaxJarRateLocationHttpFactory(new HttpClient());
        }
        
        [Fact]
        public void GetLocation_US()
        {
            var address = new Address(
                Guid.NewGuid(), 
                "US",
                "12345",
                "FL",
                "Miami",
                "street"
                );

            Assert.IsType<TaxJarUsRateLocation>(_rateLocationFactory.GetRateLocationByAddress(address));

            var addressNoCountry = new Address(
                Guid.NewGuid(), 
                "",
                "12345",
                "FL",
                "Miami",
                "street"
            );

            Assert.IsType<TaxJarUsRateLocation>(_rateLocationFactory.GetRateLocationByAddress(addressNoCountry));

        }

        [Fact]
        public void GetLocation_Exception()
        {
            var address = new Address(
                Guid.NewGuid(), 
                "ES",
                "12345",
                "FL",
                "city",
                "street"
            );

            Assert.Throws<TaxJarRateCountryNotImplementedException>(() => _rateLocationFactory.GetRateLocationByAddress(address));

        }

    }
}
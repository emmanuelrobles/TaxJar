using System;
using Core.Classes;
using TaxJar.Classes;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarRateLocationHttpTest
    {
        [Fact]
        public void TaxJarRate_QS_Builder()
        {
            Assert.Equal("?country=US&state=FL&city=Miami&street=street&",TaxJarRateLocationHttp.GetQueryString( new Address(
                Guid.NewGuid(), 
                "US",
                "",
                "FL",
                "Miami",
                "street"
            )));

            Assert.Equal("?state=FL&city=Miami&street=street&",TaxJarRateLocationHttp.GetQueryString( new Address(
                Guid.NewGuid(), 
                "",
                "",
                "FL",
                "Miami",
                "street"
            )));
            
            Assert.Equal("?country=US&city=Miami&street=street&",TaxJarRateLocationHttp.GetQueryString( new Address(
                Guid.NewGuid(), 
                "US",
                "",
                "",
                "Miami",
                "street"
            )));
            
            Assert.Equal("?country=US&state=FL&street=street&",TaxJarRateLocationHttp.GetQueryString( new Address(
                Guid.NewGuid(), 
                "US",
                "",
                "FL",
                "",
                "street"
            )));
            
            Assert.Equal("?country=US&state=FL&city=Miami&",TaxJarRateLocationHttp.GetQueryString( new Address(
                Guid.NewGuid(), 
                "US",
                "",
                "FL",
                "Miami",
                ""
            )));
            
        }
    }
}
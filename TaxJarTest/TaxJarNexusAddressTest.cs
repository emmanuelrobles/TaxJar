using System;
using Core.Classes;
using TaxJar.Classes;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarNexusAddressTest
    {
        [Fact]
        public void TaxJarNexusAddress_No_Country_Exception()
        {
            var address = new Address(
                Guid.NewGuid(),
                "",
                "12345",
                "FL",
                "Miami",
                "street"
            );

            var ex = Assert.Throws<ArgumentException>(() => new TaxJarNexusAddress(address));
            Assert.Equal($"Country should not be null or empty (Parameter '{nameof(address.Country)}')",ex.Message);
        }

        [Fact]
        public void TaxJarNexusAddress_No_State_Exception()
        {
            var address = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "",
                "Miami",
                "street"
            );

            var ex = Assert.Throws<ArgumentException>(() => new TaxJarNexusAddress(address));
            Assert.Equal($"State should not be null or empty (Parameter '{nameof(address.State)}')",ex.Message);
        }
    }
}
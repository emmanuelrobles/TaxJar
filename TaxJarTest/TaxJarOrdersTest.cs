using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Classes;
using TaxJar;
using TaxJar.Classes;
using Xunit;

namespace TaxJarTest
{
    public class TaxJarOrders
    {
        [Fact]
        public void TaxJarOrderEntry_Country_Exception()
        {
            var fromAddress = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "",
                "12345",
                "FL",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddress, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"To Address Country cannot be empty and can only have 2 letters (Parameter '{nameof(toAddress.Country)}')",
                ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Country_US_State_Exception()
        {
            var fromAddress = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddress, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal($"To Address State cannot be empty (Parameter '{nameof(toAddress.State)}')", ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Country_CA_State_Exception()
        {
            var fromAddress = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "CA",
                "12345",
                "",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddress, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal($"To Address State cannot be empty (Parameter '{nameof(toAddress.State)}')", ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Country_US_Zip_Exception()
        {
            var fromAddress = new Address(
                Guid.NewGuid(),
                "US",
                "12345",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "",
                "FL",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddress, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal($"To Address Zipcode cannot be empty (Parameter '{nameof(toAddress.ZipCode)}')", ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Nexus_Address_Empty_Exception()
        {
            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "",
                "12345",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "FL",
                "FL",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"Either an address on file, nexus_addresses parameter, or From Address parameters are required",
                ex.Message);

            var fromAddressWrongZip = new Address(
                Guid.NewGuid(),
                "Us",
                "",
                "FL",
                "city",
                "street"
            );

            order = new Order(Guid.NewGuid(), fromAddressWrongZip, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"Either an address on file, nexus_addresses parameter, or From Address parameters are required",
                ex.Message);

            var fromAddressWrongState = new Address(
                Guid.NewGuid(),
                "Us",
                "12345",
                "",
                "city",
                "street"
            );

            order = new Order(Guid.NewGuid(), fromAddressWrongState, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"Either an address on file, nexus_addresses parameter, or From Address parameters are required",
                ex.Message);

            var fromAddressWrongCity = new Address(
                Guid.NewGuid(),
                "Us",
                "12345",
                "FL",
                "",
                "street"
            );

            order = new Order(Guid.NewGuid(), fromAddressWrongCity, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"Either an address on file, nexus_addresses parameter, or From Address parameters are required",
                ex.Message);

            var fromAddressWrongStreet = new Address(
                Guid.NewGuid(),
                "Us",
                "12345",
                "FL",
                "city",
                ""
            );

            order = new Order(Guid.NewGuid(), fromAddressWrongStreet, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal(
                $"Either an address on file, nexus_addresses parameter, or From Address parameters are required",
                ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Line_Item_Amount_Empty_Exception()
        {
            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), null, 1.5m,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal($"You should have either and amount or line items", ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Shipping_Empty_Exception()
        {
            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );

            var order = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), 1.5m, null,
                new List<LineItem>());
            var ex = Assert.Throws<ArgumentNullException>(() => new TaxJarTaxOrderEntry(order));
            Assert.Equal($"Shipping is required (Parameter '{nameof(order.Shipping)}')", ex.Message);
        }

        [Fact]
        public void TaxJarOrderEntry_Amount_Line_Items()
        {
            var fromAddressWrongCountry = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );

            var toAddress = new Address(
                Guid.NewGuid(),
                "US",
                "Fl",
                "FL",
                "city",
                "street"
            );
            var orderNoItems = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), 1.5m, 1.5m,
                new List<LineItem>());
            Assert.NotNull(orderNoItems);

            var item = new LineItem(
                Guid.NewGuid(),
                1,
                "2001",
                1.5m,
                0.9m
            );
            
            var orderNoAmount = new Order(Guid.NewGuid(), fromAddressWrongCountry, toAddress, new List<Address>(), null, 1.5m,
                new []{item});
            Assert.NotNull(orderNoAmount);
        }
    }
}
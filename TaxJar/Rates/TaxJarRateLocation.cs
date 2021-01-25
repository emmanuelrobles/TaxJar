using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Classes;

namespace TaxJar.Classes
{
    public abstract class TaxJarRateLocation
    {
        protected Address _address;

        protected TaxJarRateLocation(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.ZipCode))
                throw new ArgumentException("ZipCode cannot be empty", nameof(address.ZipCode));
            
            _address = address;
        }
        public abstract Task<IEnumerable<TaxRate>> GetTaxRatesAsync();
    }
}
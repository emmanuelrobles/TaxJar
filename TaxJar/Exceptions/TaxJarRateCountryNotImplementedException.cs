using System;

namespace TaxJar.Exceptions
{
    public class TaxJarRateCountryNotImplementedException: Exception
    {
        public TaxJarRateCountryNotImplementedException(string country):base($"Country not Implemented: {country}")
        {
            
        }
    }
}
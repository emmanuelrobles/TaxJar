using System;

namespace TaxJar.Exceptions
{
    public class TaxJarTaxesForOrderException: Exception
    {
        public TaxJarTaxesForOrderException(string msg): base(msg)
        {
            
        }

    }
}
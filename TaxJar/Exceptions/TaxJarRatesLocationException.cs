using System;

namespace TaxJar.Exceptions
{
    public class TaxJarRatesLocationException : Exception
    {
        public TaxJarRatesLocationException(string msg): base (msg)
        {
            
        }
    }
}
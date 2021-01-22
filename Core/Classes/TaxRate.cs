using System;

namespace Core.Classes
{
    public class TaxRate
    {
        public decimal Rate { get; private set; }

        public TaxRate(decimal rate)
        {
            Rate = rate;
        }
    }
}
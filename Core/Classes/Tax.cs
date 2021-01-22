namespace Core.Classes
{
    public class Tax
    {
        public decimal Rate { get; private set; }
        public decimal TaxableAmount { get; private set; }

        public Tax(decimal rate, decimal taxableAmount)
        {
            Rate = rate;
            TaxableAmount = taxableAmount;
        }
    }
}
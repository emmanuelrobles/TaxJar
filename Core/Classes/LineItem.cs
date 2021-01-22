using System;

namespace Core.Classes
{
    public class LineItem
    {
        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
        public string TaxCode { get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }

        public LineItem(Guid id, int quantity, string taxCode, decimal price, decimal discount)
        {
            Id = id;
            Quantity = quantity;
            TaxCode = taxCode;
            Price = price;
            Discount = discount;
        }
    }
}
using Core.Classes;
using Newtonsoft.Json;

namespace TaxJar.Classes
{
    public class TaxJarLineItems
    {
        [JsonProperty("id")] public string Id { get; private set; }
        [JsonProperty("quantity")] public int Quantity { get; private set; }
        [JsonProperty("product_tax_code")] public string ProductTaxCode { get; private set; }
        [JsonProperty("unit_price")] public decimal Price { get; private set; }
        [JsonProperty("discount")] public decimal Discount { get; private set; }

        public TaxJarLineItems(LineItem item)
        {
            Id = item.Id.ToString();
            Quantity = item.Quantity;
            ProductTaxCode = item.TaxCode;
            Price = item.Price;
            Discount = item.Discount;
        }
    }
}
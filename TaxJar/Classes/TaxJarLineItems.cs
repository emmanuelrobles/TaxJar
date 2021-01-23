using Core.Classes;
using Newtonsoft.Json;

namespace TaxJar.Classes
{
    public class TaxJarLineItems
    {
        [JsonProperty("id")] public string Id { get; private set; }
        [JsonProperty("quantity")] public string Quantity { get; private set; }
        [JsonProperty("product_tax_code")] public string ProductTaxCode { get; private set; }
        [JsonProperty("unit_price")] public string Price { get; private set; }
        [JsonProperty("discount")] public string Discount { get; private set; }

        public TaxJarLineItems(LineItem item)
        {
            
        }
    }
}
namespace TaxJar.Classes
{
    public class TaxJarRate   {
        public string zip { get; set; } 
        public string state { get; set; } 
        public string state_rate { get; set; } 
        public string county { get; set; } 
        public string county_rate { get; set; } 
        public string city { get; set; } 
        public string city_rate { get; set; } 
        public string combined_district_rate { get; set; } 
        public string combined_rate { get; set; } 
        public bool freight_taxable { get; set; } 
    }
    
    public class TaxJarRatesResponse
    {
        public TaxJarRate Rate { get; set; }
    }
}
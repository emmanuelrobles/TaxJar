using System.Collections.Generic;

namespace TaxJar.Classes
{
    
        public class TaxJarJurisdictionsResponse    {
        public string country { get; set; } 
        public string state { get; set; } 
        public string county { get; set; } 
        public string city { get; set; } 
    }

    public class TaxJarLineItemResponse    {
        public string id { get; set; } 
        public decimal taxable_amount { get; set; } 
        public decimal tax_collectable { get; set; } 
        public decimal combined_tax_rate { get; set; } 
        public decimal state_taxable_amount { get; set; } 
        public decimal state_sales_tax_rate { get; set; } 
        public decimal state_amount { get; set; } 
        public decimal county_taxable_amount { get; set; } 
        public decimal county_tax_rate { get; set; } 
        public decimal county_amount { get; set; } 
        public decimal city_taxable_amount { get; set; } 
        public decimal city_tax_rate { get; set; } 
        public decimal city_amount { get; set; } 
        public decimal special_district_taxable_amount { get; set; } 
        public decimal special_tax_rate { get; set; } 
        public decimal special_district_amount { get; set; } 
    }

    public class TaxJarBreakdownResponse    {
        public decimal taxable_amount { get; set; } 
        public decimal tax_collectable { get; set; } 
        public decimal combined_tax_rate { get; set; } 
        public decimal state_taxable_amount { get; set; } 
        public decimal state_tax_rate { get; set; } 
        public decimal state_tax_collectable { get; set; } 
        public decimal county_taxable_amount { get; set; } 
        public decimal county_tax_rate { get; set; } 
        public decimal county_tax_collectable { get; set; } 
        public decimal city_taxable_amount { get; set; } 
        public decimal city_tax_rate { get; set; } 
        public decimal city_tax_collectable { get; set; } 
        public decimal special_district_taxable_amount { get; set; } 
        public decimal special_tax_rate { get; set; } 
        public decimal special_district_tax_collectable { get; set; } 
        public List<TaxJarLineItemResponse> line_items { get; set; } 
    }

    public class TaxJarTaxResponse    {
        public decimal order_total_amount { get; set; } 
        public decimal shipping { get; set; } 
        public decimal taxable_amount { get; set; } 
        public decimal amount_to_collect { get; set; } 
        public decimal rate { get; set; } 
        public bool has_nexus { get; set; } 
        public bool freight_taxable { get; set; } 
        public string tax_source { get; set; } 
        public TaxJarJurisdictionsResponse jurisdictions { get; set; } 
        public TaxJarBreakdownResponse breakdown { get; set; } 
    }

    public class TaxJarTaxOrderResponse    {
        public TaxJarTaxResponse tax { get; set; } 
    }
    
}
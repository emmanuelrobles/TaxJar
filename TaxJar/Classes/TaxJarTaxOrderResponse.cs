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
        public int taxable_amount { get; set; } 
        public double tax_collectable { get; set; } 
        public double combined_tax_rate { get; set; } 
        public int state_taxable_amount { get; set; } 
        public double state_sales_tax_rate { get; set; } 
        public double state_amount { get; set; } 
        public int county_taxable_amount { get; set; } 
        public double county_tax_rate { get; set; } 
        public double county_amount { get; set; } 
        public int city_taxable_amount { get; set; } 
        public int city_tax_rate { get; set; } 
        public int city_amount { get; set; } 
        public int special_district_taxable_amount { get; set; } 
        public double special_tax_rate { get; set; } 
        public double special_district_amount { get; set; } 
    }

    public class TaxJarBreakdownResponse    {
        public int taxable_amount { get; set; } 
        public double tax_collectable { get; set; } 
        public double combined_tax_rate { get; set; } 
        public int state_taxable_amount { get; set; } 
        public double state_tax_rate { get; set; } 
        public double state_tax_collectable { get; set; } 
        public int county_taxable_amount { get; set; } 
        public double county_tax_rate { get; set; } 
        public double county_tax_collectable { get; set; } 
        public int city_taxable_amount { get; set; } 
        public int city_tax_rate { get; set; } 
        public int city_tax_collectable { get; set; } 
        public int special_district_taxable_amount { get; set; } 
        public double special_tax_rate { get; set; } 
        public double special_district_tax_collectable { get; set; } 
        public List<TaxJarLineItemResponse> line_items { get; set; } 
    }

    public class TaxJarTaxResponse    {
        public double order_total_amount { get; set; } 
        public double shipping { get; set; } 
        public decimal taxable_amount { get; set; } 
        public double amount_to_collect { get; set; } 
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
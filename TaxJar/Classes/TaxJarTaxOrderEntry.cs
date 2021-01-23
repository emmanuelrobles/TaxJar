using System;
using System.Collections.Generic;
using System.Linq;
using Core.Classes;
using Newtonsoft.Json;

namespace TaxJar.Classes
{
    public class TaxJarTaxOrderEntry
    {
        [JsonProperty("from_country")] public string FromCountry { get; private set; }
        [JsonProperty("from_zip")] public string FromZipCode { get; private set; }
        [JsonProperty("from_state")] public string FromState { get; private set; }
        [JsonProperty("from_city")] public string FromCity { get; private set; }
        [JsonProperty("from_street")] public string FromStreet { get; private set; }

        [JsonProperty("to_country")] public string ToCountry { get; private set; }
        [JsonProperty("to_zip")] public string ToZipCode { get; private set; }
        [JsonProperty("to_state")] public string ToState { get; private set; }
        [JsonProperty("to_city")] public string ToCity { get; private set; }
        [JsonProperty("to_street")] public string ToStreet { get; private set; }
        
        [JsonProperty("amount")] public decimal Amount { get; private set; }
        [JsonProperty("shipping")] public decimal Shipping { get; private set; }
        
        [JsonProperty("nexus_addresses")] public IEnumerable<TaxJarNexusAddress> NexusAddress { get; private set; }
        [JsonProperty("line_items")] public IEnumerable<TaxJarLineItems> Items { get; private set; }

        public TaxJarTaxOrderEntry(Order order)
        {
            // If there is no Nexus Address all the FromAddress params must be declared
            if (!order.NexusAddress.Any() &&
                (
                    string.IsNullOrWhiteSpace(order.FromAddress.Country) ||
                    string.IsNullOrWhiteSpace(order.FromAddress.ZipCode) ||
                    string.IsNullOrWhiteSpace(order.FromAddress.State) ||
                    string.IsNullOrWhiteSpace(order.FromAddress.City) ||
                    string.IsNullOrWhiteSpace(order.FromAddress.Street)
                )) throw new ArgumentException("Either an address on file, nexus_addresses parameter, or From Address parameters are required");

                //FromAddress
            FromCountry = order.FromAddress.Country;
            FromZipCode = order.FromAddress.ZipCode;
            FromState = order.FromAddress.State;
            FromCity = order.FromAddress.City;
            FromStreet = order.FromAddress.Street;
            
            //ToAddress
            // Per Docs, the to_ country cannot be null and only have 2 letters, https://developers.taxjar.com/api/reference/#post-calculate-sales-tax-for-an-order
            if (string.IsNullOrWhiteSpace(order.ToAddress.Country)) 
                throw new ArgumentException("To Address Country cannot be empty and can only have 2 letters", nameof(order.ToAddress.Country));
            if (order.ToAddress.Country.ToUpper() == "US" || order.ToAddress.Country.ToUpper() == "CA")
            {
                if(string.IsNullOrWhiteSpace(order.ToAddress.State)) 
                    throw new ArgumentException("To Address State cannot be empty", nameof(order.ToAddress.State));
                
                if(order.ToAddress.Country.ToUpper() == "US" && string.IsNullOrWhiteSpace(order.ToAddress.ZipCode)) 
                    throw new ArgumentException("To Address Zipcode cannot be empty ", nameof(order.ToAddress.ZipCode));
            }
            ToCountry = order.ToAddress.Country;
            ToZipCode = order.ToAddress.ZipCode;
            ToState = order.ToAddress.State;
            ToCity = order.ToAddress.City;
            ToStreet = order.ToAddress.Street;

            if (!order.Items.Any() && order.Amount == null) throw new ArgumentException("You should have either and amount or line items");
            if (order.Amount != null) Amount = (decimal) order.Amount;

            Shipping = order.Shipping;

            NexusAddress = order.NexusAddress.Select(na => new TaxJarNexusAddress(na));
            Items = order.Items.Select(i => new TaxJarLineItems(i));
        }
        
    }
}
using System;
using System.Net.Http;
using Core.Classes;
using Newtonsoft.Json;

namespace TaxJar.Classes
{
    public class TaxJarRateLocationHttpFactory
    {
        public TaxJarRateLocation GetRateLocationByAddress(Address address, HttpClient client)
        {

            var country = string.IsNullOrWhiteSpace(address.Country) ? "US" : address.Country.ToUpper(); // if the country is not define we put it to US 
            
            switch (country)
            {
                case "US":
                    return new TaxJarUsRateLocation(address, client);
                default:
                    throw new NotImplementedException();
            }
            
        }

    }
}
using System;
using System.Net.Http;
using Core.Classes;
using Newtonsoft.Json;
using TaxJar.Exceptions;

namespace TaxJar.Classes
{
    public class TaxJarRateLocationHttpFactory: ITaxJarRateLocationFactory
    {

        private readonly HttpClient _client;

        public TaxJarRateLocationHttpFactory(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        
        public TaxJarRateLocation GetRateLocationByAddress(Address address)
        {

            var country = string.IsNullOrWhiteSpace(address.Country) ? "US" : address.Country.ToUpper(); // if the country is not define we put it to US 
            
            switch (country)
            {
                case "US":
                    return new TaxJarUsRateLocation(address, _client);
                default:
                    throw new TaxJarRateCountryNotImplementedException(country);
            }
            
        }

    }
}
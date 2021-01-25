using System;
using Core.Classes;
using Newtonsoft.Json;

namespace TaxJar.Classes
{
    public class TaxJarNexusAddress
    {
        [JsonProperty("id")] public string Id { get; private set; }
        [JsonProperty("country")] public string Country { get; private set; }
        [JsonProperty("zip")] public string ZipCode { get; private set; }
        [JsonProperty("state")] public string State { get; private set; }
        [JsonProperty("city")] public string City { get; private set; }
        [JsonProperty("street")] public string Street { get; private set; }

        public TaxJarNexusAddress(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.Country))
            {
                throw new ArgumentException("Country should not be null or empty", nameof(address.Country));
            }
            
            if (string.IsNullOrWhiteSpace(address.State))
            {
                throw new ArgumentException("State should not be null or empty", nameof(address.State));
            }
            
            Id = address.Id.ToString(); // if this is not the ID we could have a DB to link them
            Country = address.Country;
            ZipCode = address.ZipCode;
            State = address.State;
            City = address.City;
            Street = address.Street;
        }
        
    }
}
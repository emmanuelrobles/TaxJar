using System;
using System.Net.Http;
using System.Text;
using Core.Classes;

namespace TaxJar.Classes
{
    public abstract class TaxJarRateLocationHttp : TaxJarRateLocation
    {
        protected HttpClient _client;
        
        protected TaxJarRateLocationHttp(Address address, HttpClient client) : base(address)
        {
            _client = client;
        }

        public static string GetQueryString(Address address)
        {
            var stringBuilder = new StringBuilder("?");
            if (!string.IsNullOrWhiteSpace(address.Country)) stringBuilder.Append($"country={Uri.EscapeUriString(address.Country)}&");
            if (!string.IsNullOrWhiteSpace(address.State)) stringBuilder.Append($"state={Uri.EscapeUriString(address.State)}&");
            if (!string.IsNullOrWhiteSpace(address.City)) stringBuilder.Append($"city={Uri.EscapeUriString(address.City)}&");
            if (!string.IsNullOrWhiteSpace(address.Street)) stringBuilder.Append($"street={Uri.EscapeUriString(address.Street)}&");
            // if there is only '?' sign return an empty string
            return stringBuilder.Length == 1 ? "" : stringBuilder.ToString();
        }
    }
}
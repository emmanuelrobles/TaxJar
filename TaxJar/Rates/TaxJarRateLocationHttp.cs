using System;
using System.Net.Http;
using System.Text;
using Core.Classes;

namespace TaxJar.Classes
{
    public abstract class TaxJarTaxJarRateLocationHttp : TaxJarRateLocation
    {
        protected HttpClient _client;
        
        protected TaxJarTaxJarRateLocationHttp(Address address, HttpClient client) : base(address)
        {
            _client = client;
        }

        public string GetQueryString()
        {
            var stringBuilder = new StringBuilder("?");
            if (!string.IsNullOrWhiteSpace(_address.Country)) stringBuilder.Append($"country={Uri.EscapeUriString(_address.Country)}&");
            if (!string.IsNullOrWhiteSpace(_address.State)) stringBuilder.Append($"state={Uri.EscapeUriString(_address.State)}&");
            if (!string.IsNullOrWhiteSpace(_address.City)) stringBuilder.Append($"city={Uri.EscapeUriString(_address.City)}&");
            if (!string.IsNullOrWhiteSpace(_address.Street)) stringBuilder.Append($"street={Uri.EscapeUriString(_address.Street)}&");
            // if there is only '?' sign return an empty string
            return stringBuilder.Length == 1 ? "" : stringBuilder.ToString();
        }
    }
}
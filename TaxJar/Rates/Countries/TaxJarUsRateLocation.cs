using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Classes;
using Newtonsoft.Json;
using TaxJar.Exceptions;

namespace TaxJar.Classes
{
    public class TaxJarUsRateLocation : TaxJarRateLocationHttp
    {

        public TaxJarUsRateLocation(Address address, HttpClient client) : base(address, client)
        {
        }

        public override async Task<TaxRate> GetTaxRateAsync()
        {
            var url = $"/v2/rates/{_address.ZipCode}{GetQueryString(_address)}";
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = JsonConvert.DeserializeObject<TaxJarRatesResponse>(await response.Content.ReadAsStringAsync());
                return new TaxRate(Convert.ToDecimal(content.Rate.combined_rate));
            }

            throw new TaxJarRatesLocationException("Could not get Tax rates");
            
        }
    }
}
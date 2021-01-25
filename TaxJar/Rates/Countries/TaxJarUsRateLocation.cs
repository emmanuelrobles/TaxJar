using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Classes;
using Newtonsoft.Json;
using TaxJar.Exceptions;

namespace TaxJar.Classes
{
    public class TaxJarTaxJarUsTaxJarTaxJarRateLocation : TaxJarTaxJarRateLocationHttp
    {

        public TaxJarTaxJarUsTaxJarTaxJarRateLocation(Address address, HttpClient client) : base(address, client)
        {
        }

        public override async Task<IEnumerable<TaxRate>> GetTaxRatesAsync()
        {
            var response = await _client.GetAsync($"/v2/rates/{_address.ZipCode}{GetQueryString()}");

            if (response.IsSuccessStatusCode)
            {
                var content = JsonConvert.DeserializeObject<TaxJarRatesResponse>(await response.Content.ReadAsStringAsync());
                return new[] {new TaxRate(Convert.ToDecimal(content.Rate.combined_rate))};
            }

            throw new TaxJarRatesLocationException("Could not get Tax rates");
            
        }
    }
}
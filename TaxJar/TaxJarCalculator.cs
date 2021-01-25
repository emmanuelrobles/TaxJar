using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.TaxCalculator;
using Core.Classes;
using Newtonsoft.Json;
using TaxJar.Classes;
using TaxJar.Exceptions;

namespace TaxJar
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private readonly HttpClient _client;

        public TaxJarCalculator(HttpClient client, string token)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.taxjar.com");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        public Task<IEnumerable<TaxRate>> GetTaxRatesForAddressAsync(Address address)
        {
            var rateLocationFactory = new TaxJarRateLocationHttpFactory();

            var rateLocation = rateLocationFactory.GetRateLocationByAddress(address,_client);

            return rateLocation.GetTaxRatesAsync();
        }

        public async Task<Tax> GetTaxForOrderAsync(Order order)
        {
            TaxJarTaxOrderEntry taxForTaxOrderEntry = new TaxJarTaxOrderEntry(order);
            var data = new StringContent(JsonConvert.SerializeObject(taxForTaxOrderEntry), Encoding.UTF8, "application/json");
            
           var res = await _client.PostAsync("/v2/taxes", data);

           if (res.IsSuccessStatusCode)
           {
               var content = JsonConvert.DeserializeObject<TaxJarTaxOrderResponse>(await res.Content.ReadAsStringAsync());
               return new Tax(content.tax.rate, content.tax.taxable_amount);
           }

           throw new TaxJarTaxesForOrderException("Couldn't Get Rates for order");

        }
    }
}
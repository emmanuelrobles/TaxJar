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
        private readonly ITaxJarRateLocationFactory _rateLocationFactory;
        
        public TaxJarCalculator(HttpClient client, ITaxJarRateLocationFactory rateLocationFactory)
        {
            _rateLocationFactory = rateLocationFactory;
            _client = client;
        }


        public Task<TaxRate> GetTaxRateForAddressAsync(Address address)
        {
            var rateLocation = _rateLocationFactory.GetRateLocationByAddress(address);

            return rateLocation.GetTaxRateAsync();
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
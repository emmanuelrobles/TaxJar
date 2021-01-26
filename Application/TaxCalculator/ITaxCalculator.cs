using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Classes;

namespace Application.TaxCalculator
{
    public interface ITaxCalculator
    {
        public Task<TaxRate> GetTaxRateForAddressAsync(Address address);
        public Task<Tax> GetTaxForOrderAsync(Order order);
    }
}
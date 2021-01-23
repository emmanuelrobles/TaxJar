using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Classes;

namespace Application.TaxCalculator
{
    public interface ITaxCalculator
    {
        public Task<IEnumerable<TaxRate>> GetTaxRatesForAddressAsync(Address address);
        public Task<Tax> GetTaxForOrderAsync(Order order);
    }
}
using Core.Classes;

namespace TaxJar.Classes
{
    public interface ITaxJarRateLocationFactory
    {
        public TaxJarRateLocation GetRateLocationByAddress(Address address);
    }
}
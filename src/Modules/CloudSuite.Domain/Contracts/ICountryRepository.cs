using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface ICountryRepository
    {
        Task<Country> GetByName(string countryName);

        Task<Country> GetByCode(string code3);

        Task<IEnumerable<Country>> GetList();

        Task Add(Country country);

        void Update(Country country);

        void Remove(Country country);
    }
}
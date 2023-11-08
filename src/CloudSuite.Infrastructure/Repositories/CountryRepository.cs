using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public Task Add(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetByCode(string code3)
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetByName(string countryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Country country)
        {
            throw new NotImplementedException();
        }

        public void Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface ICityRepository
    {
        Task<City> GetByCityName(string cityName);

        Task<IEnumerable<City>> GetList();

        Task Add(City city);

        void Update(City city);

        void Remove(City city);
         
    }
}
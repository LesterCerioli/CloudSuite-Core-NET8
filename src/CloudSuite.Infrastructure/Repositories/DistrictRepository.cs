using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        public Task Add(District district)
        {
            throw new NotImplementedException();
        }

        public Task<District> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<District>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(District district)
        {
            throw new NotImplementedException();
        }

        public void Update(District district)
        {
            throw new NotImplementedException();
        }
    }
}
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        public Task Add(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetByCnpj(Cnpj cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetByCreationDate(DateTimeOffset creationDate)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vendor>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public void Update(Vendor vendor)
        {
            throw new NotImplementedException();
        }
    }
}
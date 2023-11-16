using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Domain.Contracts
{
    public interface IVendorRepository
    {
        Task<Vendor> GetByCnpj(Cnpj cnpj);

        Task<Vendor> GetByName(string name);
        
        Task<Vendor> GetByCreatedOn(DateTimeOffset? createdOn);

        Task<IEnumerable<Vendor>> GetList();

        Task Add(Vendor vendor);

        void Update(Vendor vendor);

        void Remove(Vendor vendor);
    }
}
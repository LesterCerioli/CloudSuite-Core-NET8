using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface IAddressRepository
    {
        Task<Address>GetByContactName(string contactName);

        Task<Address> GetByAddressLine(string AddressLine1);


        Task<IEnumerable<Address>> GetList();

        Task Add(Address address);

        void Update(Address address);

        void Remove(Address address);
    }
}
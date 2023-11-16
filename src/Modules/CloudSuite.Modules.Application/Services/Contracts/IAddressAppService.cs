using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.ViewModel;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IAddressAppService
    {
        Task<AddressViewModel> GetByContactName(string contactName);

        Task<AddressViewModel> GetByAddressLine(string addressLine1);

        Task Save(CreateAddressCommand commandCreate);

        
    }
}
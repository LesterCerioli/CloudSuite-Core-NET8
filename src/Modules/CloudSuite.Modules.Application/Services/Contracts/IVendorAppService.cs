using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IVendorAppService
    {
		Task<VendorViewModel> GetByCnpj(Cnpj cnpj);

		Task<VendorViewModel> GetByName(string name);

		Task<VendorViewModel> GetByCreatedOn(DateTimeOffset? createdOn);

		Task Save(CreateVendorCommand commandCreate);

	}
}
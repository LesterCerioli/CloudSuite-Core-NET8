using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICountryAppService
    {
        Task<CountryViewModel> GetByName(string countryName);

        Task Save(CreateCountryCommand commandCreate);

	}
}
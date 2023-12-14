using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICountryAppService
    {
        Task<CountryViewModel> GetByName(string countryName);

        Task<CountryViewModel> GetByCode(string code3);

        Task Save(CreateCountryCommand commandCreate);
    }
}
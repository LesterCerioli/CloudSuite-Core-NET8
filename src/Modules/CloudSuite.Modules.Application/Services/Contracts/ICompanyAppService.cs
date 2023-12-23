using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.ViewModel;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICompanyAppService
    {
        Task<CompanyViewModel> GetByCnpj(Cnpj cnpj);

        Task<CompanyViewModel> GetByFantasyName(string fantasyName);

        Task<CompanyViewModel> GetByRegisterName(string registerName);

        Task Save(CreateCompanyCommand commandCreate);
    }
}
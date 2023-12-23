using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IDistrictAppService
    {
        Task<DistrictViewModel> GetByName(string name);

        Task Save(CreateDistrictCommand commandCreate);
    }
}
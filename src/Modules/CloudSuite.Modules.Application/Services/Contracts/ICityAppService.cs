using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.ViewModel;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICityAppService
    {
        Task<CityViewModel> GetByCityName(string cityName);

        Task Save(CreateCityCommand commandCreate);
        
    }
}
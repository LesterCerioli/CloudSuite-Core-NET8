using CloudSuite.Modules.Application.ViewModel;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICityAppService
    {
        Task<CityViewModel> GetByCityName(string cityName);

        //Task Save(CreareCityCommand commandCreate);
        
    }
}
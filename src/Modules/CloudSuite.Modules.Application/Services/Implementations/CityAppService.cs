using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CityAppService : ICityAppService
	{
		private readonly ICityRepository _cityRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public CityAppService(
			ICityRepository cityRepository,
			IMapper mapper,
			ILogger<ICityAppService> logger)
		{
			_cityRepository = cityRepository;
			_mapper = mapper;
			_logger = logger;
		}


		public async Task<CityViewModel> GetByCityName(string cityName)
		{
			return _mapper.Map<CityViewModel>(await _cityRepository.GetByCityName(cityName));
		}

		public async Task Save(CreateCityCommand commandCreate)
		{
			await _cityRepository.Add(commandCreate.GetEntity());
		}
	}
}
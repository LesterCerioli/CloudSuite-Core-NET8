using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CityAppService : ICityAppService
	{
        private readonly ICityRepository _cityRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public CityAppService(ICityRepository cityRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CityViewModel> GetByCityName(string cityName)
		{
			return _mapper.Map<CityViewModel>(await _cityRepository.GetByCityName(cityName));
		}

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCityCommand commandCreate)
		{
			await _cityRepository.Add(commandCreate.GetEntity());
		}
	}
}
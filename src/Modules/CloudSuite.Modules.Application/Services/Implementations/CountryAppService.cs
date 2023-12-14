using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class CountryAppService : ICountryAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CountryAppService(ICountryRepository countryRepository, IMapper mapper, ILogger logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CountryViewModel> GetByName(string countryName)
        {
            return _mapper.Map<CountryViewModel>(await _countryRepository.GetByName(countryName));
        }

        public async Task<CountryViewModel> GetByCode(string code3)
        {
            return _mapper.Map<CountryViewModel>(await _countryRepository.GetByCode(code3));
        }

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCountryCommand commandCreate)
        {
            await _countryRepository.Add(commandCreate.GetEntity());
        }
    }
}
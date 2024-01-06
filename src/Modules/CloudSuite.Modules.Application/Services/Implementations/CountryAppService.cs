using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CountryAppService : ICountryAppService
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public CountryAppService(
			ICountryRepository countryRepository,
			IMapper mapper,
			ILogger<ICountryAppService> logger)
		{
			_countryRepository = countryRepository;
			_mapper = mapper;
			_logger = logger;
		}


		public async Task<CountryViewModel> GetByName(string countryName)
		{
			return _mapper.Map<CountryViewModel>(await _countryRepository.GetByName(countryName));
		}

		public async Task Save(CreateCountryCommand commandCreate)
		{
			await _countryRepository.Add(commandCreate.GetEntity());
		}
	}
}

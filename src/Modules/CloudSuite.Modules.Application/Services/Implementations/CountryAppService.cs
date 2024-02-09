using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
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
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public CountryAppService(ICountryRepository countryRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mediator = mediator;
            _mapper = mapper;
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

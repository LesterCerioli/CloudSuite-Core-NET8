using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class StateAppService : IStateAppService
	{
		private readonly IStateRepository _stateRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public StateAppService(
			IStateRepository stateRepository,
			IMapper mapper,
			ILogger<IStateAppService> logger)
		{
			_stateRepository = stateRepository;
			_mapper = mapper;
			_logger = logger;
		}


		public async Task<StateViewModel> GetByName(string stateName)
		{
			return _mapper.Map<StateViewModel>(await _stateRepository.GetByName(stateName));
		}

		public async Task<StateViewModel> GetByUF(string uf)
		{
			return _mapper.Map<StateViewModel>(await _stateRepository.GetByUF(uf));
		}

		public async Task Save(CreateStateCommand commandCreate)
		{
			await _stateRepository.Add(commandCreate.GetEntity());
		}
	}
}
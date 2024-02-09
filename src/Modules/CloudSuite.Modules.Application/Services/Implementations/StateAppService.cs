using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class StateAppService : IStateAppService
	{
        private readonly IStateRepository _stateRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public StateAppService(IStateRepository stateRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mediator = mediator;
            _mapper = mapper;
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
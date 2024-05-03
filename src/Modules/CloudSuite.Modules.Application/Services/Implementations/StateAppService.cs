using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class StateAppService : IStateAppService
	{
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
		private readonly ILogger<StateAppService> _logger;

        public StateAppService(
            IStateRepository stateRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<StateAppService> logger)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
            _mediator = mediator;
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

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		public async Task Save(CreateStateCommand commandCreate)
		{
			var retryPolicy = Policy.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
				onRetry: (exception, timeSpan, retryCount, context) =>
				{
					_logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}");
				});


			await retryPolicy.ExecuteAsync(async () =>
			{
                await _stateRepository.Add(commandCreate.GetEntity());
				_logger.LogInformation("State added successfully.");
            });
		}
	}
}
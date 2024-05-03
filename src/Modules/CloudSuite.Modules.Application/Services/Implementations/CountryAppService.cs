using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CountryAppService : ICountryAppService
	{
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<CountryAppService> _logger;

        public CountryAppService(
            ICountryRepository countryRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<CountryAppService> logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;

        }

        public async Task<CountryViewModel> GetByName(string countryName)
		{
			return _mapper.Map<CountryViewModel>(await _countryRepository.GetByName(countryName));
		}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

		public async Task Save(CreateCountryCommand commandCreate)
		{
            var retryPolicy = Policy.Handle<Exception>().
                WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}.");
                });
            await retryPolicy.ExecuteAsync(async () =>
            {
                await _countryRepository.Add(commandCreate.GetEntity());
                _logger.LogInformation("Country added successfully.");
            });
		}
	}
}

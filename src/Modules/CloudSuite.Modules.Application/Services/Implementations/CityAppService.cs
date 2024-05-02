using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CityAppService : ICityAppService
	{
		private readonly ICityRepository _cityRepository;
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _mediator;
		private readonly ILogger<CityAppService> _logger;

		public CityAppService(
            ICityRepository cityRepository,
            IMediatorHandler mediator,
            IMapper mapper,
			ILogger<CityAppService> logger)
		{
			_cityRepository = cityRepository;
			_mapper = mapper;
			_mediator = mediator;
			_logger = logger;
		}

		public async Task<CityViewModel> GetByCityName(string cityName)
		{
			return _mapper.Map<CityViewModel>(await _cityRepository.GetByCityName(cityName));
		}

		public async Task Save(CreateCityCommand commandCreate)
		{
			var retryPolicy = Policy.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
				onRetry: (exception, timeSpan, retryCount, context) =>
				{
					_logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}.");
				});

			await retryPolicy.ExecuteAsync(async () =>
			{
                await _cityRepository.Add(commandCreate.GetEntity());
				_logger.LogInformation("City added successfully.");
            });
		}
	}
}
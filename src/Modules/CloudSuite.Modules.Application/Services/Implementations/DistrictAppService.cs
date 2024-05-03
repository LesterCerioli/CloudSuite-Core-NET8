using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class DistrictAppService : IDistrictAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<DistrictAppService> _logger;

        public DistrictAppService(
            IDistrictRepository districtRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<DistrictAppService> logger)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<DistrictViewModel> GetByName(string name)
        {
            return _mapper.Map<DistrictViewModel>(await _districtRepository.GetByName(name));

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateDistrictCommand commandCreate)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}");
                });


            await retryPolicy.ExecuteAsync(async () =>
            {
                await _districtRepository.Add(commandCreate.GetEntity());
                _logger.LogInformation("District added successfully");
            });

        }
    }
}
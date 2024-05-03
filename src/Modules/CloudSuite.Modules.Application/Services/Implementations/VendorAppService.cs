using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class VendorAppService : IVendorAppService
	{
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<VendorAppService> _logger;

        public VendorAppService(
            IVendorRepository vendorRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<VendorAppService> logger)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<VendorViewModel> GetByCnpj(Cnpj cnpj)
		{
			return _mapper.Map<VendorViewModel>(await _vendorRepository.GetByCnpj(cnpj));
		}

		public async Task<VendorViewModel> GetByCreatedOn(DateTimeOffset? createdOn)
		{
			return _mapper.Map<VendorViewModel>(await _vendorRepository.GetByCreatedOn(createdOn));	
		}

		public async Task<VendorViewModel> GetByName(string name)
		{
			return _mapper.Map<VendorViewModel>(await _vendorRepository.GetByName(name));	
		}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateVendorCommand commandCreate)
		{
            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}");
                });
            await retryPolicy.ExecuteAsync(async () =>
            {
                await _vendorRepository.Add(commandCreate.GetEntity());
                _logger.LogInformation("Vendor added successfully.");
            });
		}
	}
}
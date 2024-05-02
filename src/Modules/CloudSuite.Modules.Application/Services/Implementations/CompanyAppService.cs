using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CompanyAppService : ICompanyAppService
	{
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
		private readonly ILogger<CompanyAppService> _logger;

        public CompanyAppService(
            ICompanyRepository companyRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<CompanyAppService> logger)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _mediator = mediator;
			_logger = logger;

        }
        public async Task<CompanyViewModel> GetByCnpj(Cnpj cnpj)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByCnpj(cnpj));
		}

		public async Task<CompanyViewModel> GetByFantasyName(string fantasyName)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByFantasyName(fantasyName)); ;
		}

		public async Task<CompanyViewModel> GetByRegisterName(string registerName)
		{
			return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByRegisterName(registerName));
		}

		public async Task Save(CreateCompanyCommand commandCreate)
		{
			var retryPolicy = Policy.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
				onRetry: (exception, timeSpan, retryCount, context) =>
				{
					_logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to { exception }.");
				});

			await retryPolicy.ExecuteAsync(async () =>
			{
                await _companyRepository.Add(commandCreate.GetEntity());
				_logger.LogInformation("Company added successfully");
            });
		}
	}
}
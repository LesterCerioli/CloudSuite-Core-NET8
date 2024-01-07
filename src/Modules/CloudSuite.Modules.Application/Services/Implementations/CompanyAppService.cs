using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CompanyAppService : ICompanyAppService
	{
		private readonly ILogger _logger;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;

		public CompanyAppService(
			ICompanyRepository companyRepository,
			IMapper mapper,
			ILogger<ICompanyAppService> logger)
		{
			_logger = logger;
			_companyRepository = companyRepository;
			_mapper = mapper;
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
			await _companyRepository.Add(commandCreate.GetEntity());
		}
	}
}
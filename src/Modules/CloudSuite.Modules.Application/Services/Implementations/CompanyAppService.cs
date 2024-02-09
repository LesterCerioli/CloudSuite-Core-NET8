using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class CompanyAppService : ICompanyAppService
	{
        private readonly ICompanyRepository _companyRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public CompanyAppService(ICompanyRepository companyRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mediator = mediator;
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

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCompanyCommand commandCreate)
		{
			await _companyRepository.Add(commandCreate.GetEntity());
		}
	}
}
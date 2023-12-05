using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class VendorAppService : IVendorAppService
	{
		private readonly IMapper _mapper;
		private readonly IVendorRepository _vendorRepository;
		private readonly IMediatorHandler _mediator;

		public VendorAppService(
			IMapper mapper,
			IVendorRepository vendorRepository,
			IMediatorHandler mediator)
		{
			_mapper = mapper;
			_vendorRepository = vendorRepository;
			_mediator = mediator;
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

		public async Task Save(CreateVendorCommand commandCreate)
		{
			await _vendorRepository.Add(commandCreate.GetEntity());
		}
	}
}
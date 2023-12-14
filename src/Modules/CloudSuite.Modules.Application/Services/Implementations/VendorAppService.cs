using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Handlers.Vendor;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class VendorAppService : IVendorAppService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public VendorAppService(IVendorRepository vendorRepository, IMapper mapper, ILogger logger)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
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

        public async Task Save(CreateVendorCommand commandCreate)
        {
            await _vendorRepository.Add(commandCreate.GetEntity());
        }
    }
}
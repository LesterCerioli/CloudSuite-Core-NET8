using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddressAppService(
            IAddressRepository addressRepository,
            IMapper mapper,
            ILogger logger
        )
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<AddressViewModel> GetByAddressLine(string addressLine1)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetByAddressLine(addressLine1));
        }

        public async Task<AddressViewModel> GetByContactName(string contactName)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetByContactName(contactName));
        }

        public async Task Save(CreateAddressCommand commandCreate)
        {
            throw new NotImplementedException();
        }

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync(CreateAddressCommand commandCreate)
        {
            await _addressRepository.Add(commandCreate.GetEntity());
        }
    }
}
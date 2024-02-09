using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class AddressAppService : IAddressAppService
	{

        private readonly IAddressRepository _addressRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public AddressAppService(IAddressRepository addressRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<AddressViewModel> GetByAddressLine(string addressLine1)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetByAddressLine(addressLine1));
        }

        public async Task<AddressViewModel> GetByContactName(string contactName)
        {
            return _mapper.Map<AddressViewModel>(await _addressRepository.GetByContactName(contactName));
        }

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateAddressCommand commandCreate)
        {
            await _addressRepository.Add(commandCreate.GetEntity());
        }
	}
}

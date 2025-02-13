﻿using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class AddressAppService : IAddressAppService
	{

        private readonly IAddressRepository _addressRepository;
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _mediator;
        private readonly ILogger<AddressAppService> _logger;
		
		public AddressAppService(
			IAddressRepository addressRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<AddressAppService> logger)
		{
			_addressRepository = addressRepository;
            _mapper = mapper;
            _mediator = mediator;
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

        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

		public async Task Save(CreateAddressCommand commandCreate)
		{
            var retryPolicy = Policy.Handle<Exception>()
                              .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                              onRetry: (exception, timeSpan, retryCount, context) =>
                              {
                                  _logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}");
                              });

            await retryPolicy.ExecuteAsync(async () =>
            {
                await _addressRepository.Add(commandCreate.GetEntity());
                _logger.LogInformation("Address added successfully.");
            });
		}
	}
}

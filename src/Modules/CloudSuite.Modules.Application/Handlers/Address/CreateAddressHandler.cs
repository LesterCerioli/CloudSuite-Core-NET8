using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using CloudSuite.Modules.Application.Validations.Address;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, CreateAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateAddressHandler> _logger;

        public CreateAddressHandler(IAddressRepository adressRepository, ILogger<CreateAddressHandler> logger)
        {
            _addressRepository = adressRepository;
            _logger = logger;
        }

        public async Task<CreateAddressResponse> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateExtractCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateAddressCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var adressExistAdressLine = await _addressRepository.GetByAddressLine(command.AddressLine1);
                    var adressExistContactName = await _addressRepository.GetByContactName(command.ContactName);

                    if (adressExistAdressLine == null && adressExistContactName == null)
                    {
                        await _addressRepository.Add(command.GetEntity());
                        return new CreateAddressResponse(command.Id, validationResult);
                    }

                    return new CreateAddressResponse(command.Id, "Address already registered");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating extract");
                    return new CreateAddressResponse(command.Id, "Error creating Adress");
                }
            }
                    return new CreateAddressResponse(command.Id, validationResult);
        }
    }
}
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using CloudSuite.Modules.Application.Validations.Address;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CheckAddressExistsByContactNameHandler : IRequestHandler<CheckAddressExistsByContactNameRequest, CheckAddressExistsByContactNameResponse>
    {
        private IAddressRepository _addressRepository;
        private readonly ILogger<CheckAddressExistsByAddressLineHandler> _logger;


        public async Task<CheckAddressExistsByContactNameResponse> Handle(CheckAddressExistsByContactNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAddressExistsByContactNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var contactName = await _addressRepository.GetByContactName(request.ContactName);

                    if (contactName != null)
                    {
                        return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, false, validationResult));
        }
    }
}

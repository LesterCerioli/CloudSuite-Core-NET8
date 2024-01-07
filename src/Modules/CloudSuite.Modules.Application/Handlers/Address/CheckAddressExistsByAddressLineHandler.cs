using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using CloudSuite.Modules.Application.Validations.Address;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CheckAddressExistsByAddressLineHandler : IRequestHandler<CheckAddressExistsByAddressLineRequest, CheckAddressExistsByAddressLineResponse>
    {
        private IAddressRepository _addressRepository;
        private readonly ILogger<CheckAddressExistsByAddressLineHandler> _logger;


        public async Task<CheckAddressExistsByAddressLineResponse> Handle(CheckAddressExistsByAddressLineRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAddressExistsByAddressLineRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var adressLine = await _addressRepository.GetByAddressLine(request.AddressLine1);

                    if (adressLine != null)
                    {
                        return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, false, validationResult));
        }
    }
}

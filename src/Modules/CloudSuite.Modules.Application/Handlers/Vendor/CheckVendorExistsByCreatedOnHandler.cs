using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using CloudSuite.Modules.Application.Validations.Vendor;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CheckVendorExistsByCreatedOnHandler : IRequestHandler<CheckVendorExistsByCreatedOnRequest, CheckVendorExistsByCreatedOnResponse>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<CheckVendorExistsByCreatedOnHandler> _logger;

        public CheckVendorExistsByCreatedOnHandler(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByCreatedOnHandler> logger)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
        }
        public async Task<CheckVendorExistsByCreatedOnResponse> Handle(CheckVendorExistsByCreatedOnRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVendorExistsByCreationDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVendorExistsByCreationDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var vendorCreationDate = await _vendorRepository.GetByCreatedOn(request.CreatedOn);

                    if (vendorCreationDate != null)
                    {
                        return await Task.FromResult(new CheckVendorExistsByCreatedOnResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVendorExistsByCreatedOnResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckVendorExistsByCreatedOnResponse(request.Id, false, validationResult));

        }
    }
}

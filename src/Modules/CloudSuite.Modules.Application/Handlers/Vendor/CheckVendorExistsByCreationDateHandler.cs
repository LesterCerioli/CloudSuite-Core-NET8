using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using CloudSuite.Modules.Application.Validations.Vendor;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CheckVendorExistsByCreationDateHandler : IRequestHandler<CheckVendorExistsByCreationDateRequest, CheckVendorExistsByCreationDateResponse>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<CheckVendorExistsByCreationDateHandler> _logger;

        public CheckVendorExistsByCreationDateHandler(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByCreationDateHandler> logger)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
        }
        public async Task<CheckVendorExistsByCreationDateResponse> Handle(CheckVendorExistsByCreationDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVendorExistsByCreationDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVendorExistsByCreationDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var vendorCreationDate = await _vendorRepository.GetByCreationDate(request.CreatedOn);

                    if (vendorCreationDate != null)
                    {
                        return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, false, validationResult));

        }
    }
}

using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using CloudSuite.Modules.Application.Validations.Vendor;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CheckVendorExistsByNameHandler : IRequestHandler<CheckVendorExistsByNameRequest, CheckVendorExistsByNameResponse>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<CheckVendorExistsByNameHandler> _logger;

        public CheckVendorExistsByNameHandler(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByNameHandler> logger)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
        }
        public async Task<CheckVendorExistsByNameResponse> Handle(CheckVendorExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVendorExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVendorExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var vendorName = await _vendorRepository.GetByName(request.Name);

                    if (vendorName != null)
                    {
                        return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, false, validationResult));

        }
    }
}

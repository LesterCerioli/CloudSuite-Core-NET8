using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.District.Request;
using CloudSuite.Modules.Application.Handlers.District.Responses;
using CloudSuite.Modules.Application.Validations.District;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.District
{
    public class CheckDistrictExistsByNameHandler : IRequestHandler<CheckDistrictExistsByNameRequest, CheckDistrictExistsByNameResponse>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly ILogger<CheckDistrictExistsByNameHandler> _logger;

        public CheckDistrictExistsByNameHandler(IDistrictRepository districtRepository, ILogger<CheckDistrictExistsByNameHandler> logger)
        {
            _districtRepository = districtRepository;
            _logger = logger;
        }
        public async Task<CheckDistrictExistsByNameResponse> Handle(CheckDistrictExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckDistrictExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckDistrictExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var DistrictName = await _districtRepository.GetByName(request.Name);

                    if (DistrictName != null)
                    {
                        return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckDistrictExistsByNameResponse(request.Id, false, validationResult));

        }
    }
}

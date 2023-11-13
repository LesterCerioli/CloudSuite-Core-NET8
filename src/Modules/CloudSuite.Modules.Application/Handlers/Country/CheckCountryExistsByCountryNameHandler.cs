using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country.Request;
using CloudSuite.Modules.Application.Handlers.Country.Responses;
using CloudSuite.Modules.Application.Validations.Country;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Country
{
    public class CheckCountryExistsByCountryNameHandler : IRequestHandler<CheckCountryExistsByCountryNameRequest, CheckCountryExistsByCountryNameResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CheckCountryExistsByCountryNameHandler> _logger;

        public CheckCountryExistsByCountryNameHandler(ICountryRepository countryRepository, ILogger<CheckCountryExistsByCountryNameHandler> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<CheckCountryExistsByCountryNameResponse> Handle(CheckCountryExistsByCountryNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCountryExistsByCountryNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCountryExistsByCountryNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var countryName = await _countryRepository.GetByName(request.CountryName);

                    if (countryName != null)
                    {
                        return await Task.FromResult(new CheckCountryExistsByCountryNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCountryExistsByCountryNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCountryExistsByCountryNameResponse(request.Id, false, validationResult));
        }
    }
}

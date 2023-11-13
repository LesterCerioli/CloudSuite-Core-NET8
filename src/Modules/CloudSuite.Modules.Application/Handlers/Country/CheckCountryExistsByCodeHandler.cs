using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country.Request;
using CloudSuite.Modules.Application.Handlers.Country.Responses;
using CloudSuite.Modules.Application.Validations.Country;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Country
{
    public class CheckCountryExistsByCodeHandler : IRequestHandler<CheckCountryExistsByCodeRequest, CheckCountryExistsByCodeResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CheckCountryExistsByCountryNameHandler> _logger;

        public CheckCountryExistsByCodeHandler(ICountryRepository countryRepository, ILogger<CheckCountryExistsByCountryNameHandler> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<CheckCountryExistsByCodeResponse> Handle(CheckCountryExistsByCodeRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCountryExistsByCodeRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCountryExistsByCodeRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var countryCode = await _countryRepository.GetByCode(request.Code3);

                    if (countryCode != null)
                    {
                        return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, false, validationResult));

        }
    }
}

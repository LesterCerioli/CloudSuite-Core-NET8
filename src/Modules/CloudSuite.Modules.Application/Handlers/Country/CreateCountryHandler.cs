using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Country.Responses;
using CloudSuite.Modules.Application.Validations.Country;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Country
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CreateCountryResponse>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CreateCountryHandler> _logger;

        public CreateCountryHandler(ICountryRepository countryRepository, ILogger<CreateCountryHandler> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<CreateCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCountryCommand: {JsonSerializer.Serialize(request)}");
            var validationResult = new CreateCountryCommandValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var CountryName = await _countryRepository.GetByName(request.CountryName);
                    var CountryCode = await _countryRepository.GetByCode(request.Code3);

                    if (CountryName != null && CountryCode != null)
                    {
                        return await Task.FromResult(new CreateCountryResponse(request.Id, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateCountryResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateCountryResponse(request.Id, validationResult));
        }
    }
}

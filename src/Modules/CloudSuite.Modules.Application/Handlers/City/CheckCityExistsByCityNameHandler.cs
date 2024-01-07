using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.City.Request;
using CloudSuite.Modules.Application.Validations.City;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.City
{
    public class CheckCityExistsByCityNameHandler : IRequestHandler<CheckCityExistsByCityNameRequest, CheckCitExistsyByCityNameResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CheckCityExistsByCityNameHandler> _logger;

        public CheckCityExistsByCityNameHandler(ICityRepository cityRepository, ILogger<CheckCityExistsByCityNameHandler> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }
        public async Task<CheckCitExistsyByCityNameResponse> Handle(CheckCityExistsByCityNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCityByCityNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCityByCityNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var cityName = await _cityRepository.GetByCityName(request.CityName);

                    if (cityName != null)
                    {
                        return await Task.FromResult(new CheckCitExistsyByCityNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCitExistsyByCityNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCitExistsyByCityNameResponse(request.Id, false, validationResult));
        }
    }
}

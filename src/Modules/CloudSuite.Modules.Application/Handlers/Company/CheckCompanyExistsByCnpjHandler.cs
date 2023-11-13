using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Company.Request;
using CloudSuite.Modules.Application.Validations.Company;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsByCnpjHandler : IRequestHandler<CheckCompanyExistsByCnpjRequest, CheckCompanyExistsByCnpjResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CheckCompanyExistsByCnpjHandler> _logger;

        public CheckCompanyExistsByCnpjHandler(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByCnpjHandler> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsByCnpjResponse> Handle(CheckCompanyExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCityByCityNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var cityName = await _companyRepository.GetByCnpj(request.Cnpj);

                    if (cityName != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, false, validationResult));

        }
    }
}

using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Company.Request;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validations.Company;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsByRegisterNameHandler : IRequestHandler<CheckCompanyExistsByRegisterNameRequest, CheckCompanyExistsByRegisterNameResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CheckCompanyExistsByRegisterNameHandler> _logger;

        public CheckCompanyExistsByRegisterNameHandler(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByRegisterNameHandler> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }
        public async Task<CheckCompanyExistsByRegisterNameResponse> Handle(CheckCompanyExistsByRegisterNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsByRegisterNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByRegisterNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var cityName = await _companyRepository.GetByRegisterName(request.RegisterName);

                    if (cityName != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCompanyExistsByRegisterNameResponse(request.Id, false, validationResult));
        }
    }
}

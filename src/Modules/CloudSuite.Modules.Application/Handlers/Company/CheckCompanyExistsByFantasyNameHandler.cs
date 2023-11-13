using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Company.Request;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validations.Company;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsByFantasyNameHandler : IRequestHandler<CheckCompanyExistsByFantasyNameRequest, CheckCompanyExistsByFantasyNameResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CheckCompanyExistsByFantasyNameHandler> _logger;

        public CheckCompanyExistsByFantasyNameHandler(ICompanyRepository companyRepository, ILogger<CheckCompanyExistsByFantasyNameHandler> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }
        public async Task<CheckCompanyExistsByFantasyNameResponse> Handle(CheckCompanyExistsByFantasyNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsByFantasyNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByFantasyNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var companyFantasyName = await _companyRepository.GetByFantasyName(request.FantasyName);

                    if (companyFantasyName != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, false, validationResult));
        }
    }
}

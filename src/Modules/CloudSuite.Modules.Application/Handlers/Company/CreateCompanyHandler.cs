using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Validations.Company;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CreateCityHandler> _logger;

        public CreateCompanyHandler(ICompanyRepository companyRepository, ILogger<CreateCityHandler> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCompanyCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCompanyCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var companyCnpj = await _companyRepository.GetByCnpj(command.Cnpj);
                    var companyFantasyName = await _companyRepository.GetByFantasyName(command.FantasyName);
                    var companyRegistreName = await _companyRepository.GetByRegisterName(command.RegisterName);

                    if (companyCnpj == null && companyFantasyName == null && companyRegistreName == null)
                    {
                        await _companyRepository.Add(command.GetEntity());
                        return new CreateCompanyResponse(command.Id, validationResult);
                    }

                    return new CreateCompanyResponse(command.Id, "Company already registered"); ;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating extract");
                    return new CreateCompanyResponse(command.Id, "Error creating Adress");
                }
            }
            return new CreateCompanyResponse(command.Id, validationResult);
        }
    }
}

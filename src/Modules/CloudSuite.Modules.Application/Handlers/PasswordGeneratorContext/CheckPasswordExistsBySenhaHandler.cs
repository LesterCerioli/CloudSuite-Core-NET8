using CloudSuite.Domain.Contracts.PasswordGeneratorContext;
using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Requests;
using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Responses;
using CloudSuite.Modules.Application.Validations.PasswordGeneratorContext;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext
{
    public class CheckPasswordExistsBySenhaHandler : IRequestHandler<CheckPasswordExistsBySenhaRequest, CheckPasswordExistsBySenhaResponse>
    {
        private readonly IPasswordRepository _passwprdRepository;
        private readonly ILogger<CheckPasswordExistsBySenhaHandler> _logger;

        public CheckPasswordExistsBySenhaHandler(IPasswordRepository passwordRpository, ILogger<CheckPasswordExistsBySenhaHandler> logger) 
        {
            _passwprdRepository = passwordRpository;
            _logger = logger;
        }

        public async Task<CheckPasswordExistsBySenhaResponse> Handle(CheckPasswordExistsBySenhaRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCityExistsByCityNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPasswordExistsBySenhaRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try 
                {
                    var senha = await _passwprdRepository.GetBySecret(request.Senha);
                    if (senha != null)
                    {
                        return await Task.FromResult(new CheckPasswordExistsBySenhaResponse(request.Id, true, validationResult));

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPasswordExistsBySenhaResponse(request.Id, "Failed to process the request."));

                }
            }
            return await Task.FromResult(new CheckPasswordExistsBySenhaResponse(request.Id, false, validationResult));
        }
    }
}

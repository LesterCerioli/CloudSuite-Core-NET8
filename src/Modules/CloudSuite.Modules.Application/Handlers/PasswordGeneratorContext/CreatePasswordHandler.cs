using CloudSuite.Domain.Contracts.PasswordGeneratorContext;
using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Responses;
using CloudSuite.Modules.Application.Validations.PasswordGeneratorContext;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext
{
    public class CreatePasswordHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordRespnse>
    {
        private readonly IPasswordRepository _passowrdRepository;
        private readonly ILogger<CreatePasswordHandler> _logger;

        public CreatePasswordHandler(IPasswordRepository passwordRepository, ILogger<CreatePasswordHandler> logger)
        {
            _passowrdRepository = passwordRepository;
            _logger = logger;
        }

        public async Task<CreatePasswordRespnse> Handle(CreatePasswordCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatepasswordCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreatePasswordCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var senha = await _passowrdRepository.GetBySecret(command.Senha);

                    if (senha != null) 
                    {
                        await _passowrdRepository.Add(command.GetEntity());
                        return new CreatePasswordRespnse(command.Id, validationResult); 

                    }
                    


                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreatePasswordRespnse(command.Id, "Não foi possivel Processar solicitação."));

                }
            }

            return await Task.FromResult(new CreatePasswordRespnse(command.Id, validationResult));
        }

    }
}

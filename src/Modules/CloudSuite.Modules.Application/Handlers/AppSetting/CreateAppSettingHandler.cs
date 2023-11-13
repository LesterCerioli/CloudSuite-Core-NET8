using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using CloudSuite.Modules.Application.Validations.AppSetting;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting
{
    public class CreateAppSettingHandler : IRequestHandler<CreateAppSettingCommand, CreateAppSettingResponse>
    {
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly ILogger<CreateAddressHandler> _logger;

        public CreateAppSettingHandler(IAppSettingRepository appSettingRepository, ILogger<CreateAddressHandler> logger)
        {
            _appSettingRepository = appSettingRepository;
            _logger = logger;
        }

        public async Task<CreateAppSettingResponse> Handle(CreateAppSettingCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateExtractCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateAppSettingCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var appSettingValue = await _appSettingRepository.GetByValue(command.Value);
                    var appSettingModule = await _appSettingRepository.GetByModule(command.Module);

                    if (appSettingValue == null && appSettingModule == null)
                    {
                        await _appSettingRepository.Add(command.GetEntity());
                        return new CreateAppSettingResponse(command.Id, validationResult);
                    }

                    return new CreateAppSettingResponse(command.Id, "Address already registered");

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating extract");
                    return new CreateAppSettingResponse(command.Id, "Error creating Adress");
                }
            }
            return new CreateAppSettingResponse(command.Id, validationResult);
        }
    }
}

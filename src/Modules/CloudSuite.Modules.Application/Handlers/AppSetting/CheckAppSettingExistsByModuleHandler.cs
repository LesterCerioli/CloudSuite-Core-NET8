using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.AppSetting.Request;
using CloudSuite.Modules.Application.Validations.AppSetting;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting
{
    public class CheckAppSettingExistsByModuleHandler : IRequestHandler<CheckAppSettingExistsByModuleRequest, CheckAppSettingByModuleResponse>
    {
        private IAppSettingRepository _appSettingRepository;
        private readonly ILogger<CheckAppSettingExistsByValueHandler> _logger;

        public async Task<CheckAppSettingByModuleResponse> Handle(CheckAppSettingExistsByModuleRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckAppSettingByValueRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAppSettingByModuleRequestValidations().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var appSttingModule = await _appSettingRepository.GetByModule(request.Module);

                    if (appSttingModule != null)
                    {
                        return await Task.FromResult(new CheckAppSettingByModuleResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAppSettingByModuleResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckAppSettingByModuleResponse(request.Id, false, validationResult));
        }
    }
}

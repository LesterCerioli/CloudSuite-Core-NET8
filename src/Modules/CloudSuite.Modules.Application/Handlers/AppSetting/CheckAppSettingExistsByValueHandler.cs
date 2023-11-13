using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.AppSetting.Request;
using CloudSuite.Modules.Application.Validations.AppSetting;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting
{
    public class CheckAppSettingExistsByValueHandler : IRequestHandler<CheckAppSettingExistsByValueRequest, CheckAppSettingByValueResponse>
    {

        private IAppSettingRepository _appSettingRepository;
        private readonly ILogger<CheckAppSettingExistsByValueHandler> _logger;
        public async Task<CheckAppSettingByValueResponse> Handle(CheckAppSettingExistsByValueRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckAppSettingByValueRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAppSettingByValueRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var appSttingValue = await _appSettingRepository.GetByValue(request.Value);

                    if (appSttingValue != null)
                    {
                        return await Task.FromResult(new CheckAppSettingByValueResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAppSettingByValueResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckAppSettingByValueResponse(request.Id, false, validationResult));
        }
    }
}

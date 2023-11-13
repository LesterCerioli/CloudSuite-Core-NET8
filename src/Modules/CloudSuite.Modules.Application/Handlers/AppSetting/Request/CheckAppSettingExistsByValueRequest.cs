using MediatR;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting.Request
{
    public class CheckAppSettingExistsByValueRequest : IRequest<CheckAppSettingByValueResponse>
    {
        public Guid Id { get; private set; }

        public string? Value { get; private set; }

        public CheckAppSettingExistsByValueRequest(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }

        public CheckAppSettingExistsByValueRequest() { }
    }
}

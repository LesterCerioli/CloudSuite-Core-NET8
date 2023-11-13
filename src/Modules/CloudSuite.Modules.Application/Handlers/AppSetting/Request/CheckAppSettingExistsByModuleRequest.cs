using MediatR;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting.Request
{
    public class CheckAppSettingExistsByModuleRequest : IRequest<CheckAppSettingByModuleResponse>
    {
        public Guid Id { get; private set; }
        public string? Module { get; private set; }

        public CheckAppSettingExistsByModuleRequest(string module)
        {
            Id = Guid.NewGuid();
            Module = module;
        }

        public CheckAppSettingExistsByModuleRequest() { }
    }

   
}

using MediatR;
using System.ComponentModel.DataAnnotations;
using AppSettingEntity = CloudSuite.Domain.Models.AppSetting;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting
{
    public class CreateAppSettingCommand : IRequest<CreateAppSettingResponse>
    {

        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(450)]
        public string? Value { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(450)]
        public string? Module { get; private set; }

        public bool? IsVisibleInCommonSettingPage { get; private set; }



        public AppSettingEntity GetEntity()
        {
            return new AppSettingEntity(
                this.Id,
                this.Value,
                this.Module,
                this.IsVisibleInCommonSettingPage
                );
        }
    }
}

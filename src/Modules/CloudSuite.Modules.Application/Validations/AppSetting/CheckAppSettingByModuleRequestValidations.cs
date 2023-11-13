using CloudSuite.Modules.Application.Hadlers.AppSetting.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.AppSetting
{
    public class CheckAppSettingByModuleRequestValidations : AbstractValidator<CheckAppSettingExistsByModuleRequest>
    {
        public CheckAppSettingByModuleRequestValidations()
        {

            RuleFor(a => a.Module)
                .NotEmpty()
                .WithMessage("O campo Module é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Module deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s]*$")
                .WithMessage("O campo Module deve conter apenas letras, números e espaços.")
                .NotNull()
                .WithMessage("O campo Module não pode ser nulo.");
        }
    }
}

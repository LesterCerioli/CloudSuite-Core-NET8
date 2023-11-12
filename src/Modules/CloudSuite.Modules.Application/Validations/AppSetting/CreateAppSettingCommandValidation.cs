using CloudSuite.Modules.Application.Hadlers.AppSetting;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.AppSetting
{
    public class CreateAppSettingCommandValidation : AbstractValidator<CreateAppSettingCommand>
    {
        public CreateAppSettingCommandValidation()
        {
            RuleFor(a => a.Value)
                .NotEmpty()
                .WithMessage("O campo Value é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Value deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s]*$")
                .WithMessage("O campo Value deve conter apenas letras, números e espaços.")
                .NotNull()
                .WithMessage("O campo Value não pode ser nulo.");

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

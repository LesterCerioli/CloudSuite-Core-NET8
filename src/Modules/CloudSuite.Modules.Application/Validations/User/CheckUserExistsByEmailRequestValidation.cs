using CloudSuite.Modules.Application.Handlers.User.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.User
{
    public class CheckUserExistsByEmailRequestValidation : AbstractValidator<CheckUserExistsByEmailRequest>
    {
        public CheckUserExistsByEmailRequestValidation()
        {
            RuleFor(a => a.Email.Subject)
               .Length(1, 450)
               .WithMessage("O campo Subject deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Email.Body)
                .NotEmpty()
                .WithMessage("O campo Body é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Body deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Email.Sender)
                .NotEmpty()
                .WithMessage("O campo Sender é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Sender deve ser um endereço de email válido.");

            RuleFor(a => a.Email.Recipient)
                .NotEmpty()
                .WithMessage("O campo Recipient é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Recipient deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Recipient deve ser um endereço de email válido.");

            RuleFor(a => a.Email.SentDate)
               .GreaterThan(DateTimeOffset.Now)
               .WithMessage("A data deve estar no futuro.");

            RuleFor(a => a.Email.CodeErrorEmail)
                .IsInEnum()
                .WithMessage("O campo CodeErrorEmail deve ser um valor válido do enum CodeErrorEmail.");

        }
    }
}

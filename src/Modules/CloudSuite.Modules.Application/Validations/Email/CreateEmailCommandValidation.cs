using CloudSuite.Modules.Application.Handlers.Email;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Email
{
    public class CreateEmailCommandValidation : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidation() 
        {
            RuleFor(a => a.Subject)
                .Length(1, 100)
                .WithMessage("O campo Subject deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Body)
                .Length(1, 3000)
                .WithMessage("O campo Body deve ter entre 1 e 3000 caracteres.");

            RuleFor(a => a.Sender)
                .NotEmpty()
                .WithMessage("O campo Sender é obrigatório.")
                .Length(1, 80)
                .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Sender deve ser um endereço de email válido.");

            RuleFor(a => a.Recipient)
                .NotEmpty()
                .WithMessage("O campo Recipient é obrigatório.")
                .Length(1, 80)
                .WithMessage("O campo Recipient deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Recipient deve ser um endereço de email válido.");

            RuleFor(a => a.SentDate)
                .GreaterThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("A data não pode estar no passado");

            RuleFor(a => a.SendAttempts)
                .InclusiveBetween(0, int.MaxValue)
                .WithMessage("O campo SendAttempts deve ser um número inteiro positivo.");

            RuleFor(a => a.CodeErrorEmail)
                .IsInEnum()
                .WithMessage("O campo CodeErrorEmail deve ser um valor válido do enum CodeErrorEmail.");



        }
    }
}

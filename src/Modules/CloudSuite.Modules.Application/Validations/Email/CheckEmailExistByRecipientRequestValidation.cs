using CloudSuite.Modules.Application.Handlers.Email.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Email
{
    public class CheckEmailExistByRecipientRequestValidation : AbstractValidator<CheckEmailExistByRecipientRequest>
    {
        public CheckEmailExistByRecipientRequestValidation() 
        {
            RuleFor(a => a.Recipient)
                 .NotEmpty()
                 .WithMessage("O campo Recipient é obrigatório.")
                 .Length(1, 80)
                 .WithMessage("O campo Recipient deve ter entre 1 e 450 caracteres.")
                 .EmailAddress()
                 .WithMessage("O campo Recipient deve ser um endereço de email válido.");
        }
    }
}

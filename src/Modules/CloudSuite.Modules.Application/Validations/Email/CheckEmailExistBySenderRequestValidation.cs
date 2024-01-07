using CloudSuite.Modules.Application.Handlers.Email.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Email
{
    public class CheckEmailExistBySenderRequestValidation : AbstractValidator<CheckEmailExistBySenderRequest>
    {
        public CheckEmailExistBySenderRequestValidation() 
        {
            RuleFor(a => a.Sender)
                 .NotEmpty()
                 .WithMessage("O campo Sender é obrigatório.")
                 .Length(1, 80)
                 .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                 .EmailAddress()
                 .WithMessage("O campo Sender deve ser um endereço de email válido.");
        }
    }
}

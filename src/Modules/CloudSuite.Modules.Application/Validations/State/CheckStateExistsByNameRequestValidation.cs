using CloudSuite.Modules.Application.Handlers.State.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.State
{
    public class CheckStateExistsByNameRequestValidation : AbstractValidator<CheckStateExistsByNameRequest>
    {
        public CheckStateExistsByNameRequestValidation() 
        {
            RuleFor(a => a.StateName)
               .NotEmpty()
               .WithMessage("O campo StateName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo StateName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo StateName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo StateName não pode ser nulo.");

        }
    }
}

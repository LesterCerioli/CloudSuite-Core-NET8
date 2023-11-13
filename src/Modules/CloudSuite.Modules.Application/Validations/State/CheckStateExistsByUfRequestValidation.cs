using CloudSuite.Modules.Application.Handlers.State.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.State
{
    public class CheckStateExistsByUfRequestValidation : AbstractValidator<CheckStateExistsByUfRequest>
    {
        public CheckStateExistsByUfRequestValidation ()
        {
            RuleFor(a => a.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");
        }
    }
}

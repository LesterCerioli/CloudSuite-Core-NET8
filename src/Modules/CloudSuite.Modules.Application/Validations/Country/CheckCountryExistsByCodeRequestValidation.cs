using CloudSuite.Modules.Application.Handlers.Country.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Country
{
    public class CheckCountryExistsByCodeRequestValidation : AbstractValidator<CheckCountryExistsByCodeRequest>
    {
        public CheckCountryExistsByCodeRequestValidation() 
        {
            RuleFor(a => a.Code3)
                .NotEmpty()
                .WithMessage("O campo Code3 é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Code3 deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z0-9]*$")
                .WithMessage("O campo Code3 deve conter apenas letras e números.")
                .NotNull()
                .WithMessage("O campo Code3 não pode ser nulo.");
        }
    }
}

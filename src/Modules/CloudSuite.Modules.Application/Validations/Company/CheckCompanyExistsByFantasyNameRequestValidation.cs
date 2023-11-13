using CloudSuite.Modules.Application.Handlers.Company.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Company
{
    public class CheckCompanyExistsByFantasyNameRequestValidation : AbstractValidator<CheckCompanyExistsByFantasyNameRequest>
    {
        public CheckCompanyExistsByFantasyNameRequestValidation()
        {
            RuleFor(a => a.FantasyName)
                .NotEmpty()
                .WithMessage("O campo FantasyName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo FantasyName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo FantasyName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo FantasyName não pode ser nulo.");
        }
    }
}

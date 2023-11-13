using CloudSuite.Modules.Application.Handlers.Company.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Company
{
    public class CheckCompanyExistsByRegisterNameRequestValidation : AbstractValidator<CheckCompanyExistsByRegisterNameRequest>
    {
        public CheckCompanyExistsByRegisterNameRequestValidation()
        {
            RuleFor(a => a.RegisterName)
                .NotEmpty()
                .WithMessage("O campo RegisterName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo RegisterName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo RegisterName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo RegisterName não pode ser nulo.");
        }
    }
}

using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Address
{
    public class CheckAddressExistsByContactNameRequestValidation : AbstractValidator<CheckAddressExistsByContactNameRequest>
    {
        public CheckAddressExistsByContactNameRequestValidation()
        {
            RuleFor(a => a.ContactName)
            .NotEmpty()
            .WithMessage("O campo ContactName é obrigatório.")
            .Length(1, 60)
            .WithMessage("O campo ContactName deve ter entre 1 e 60 caracteres.")
            .Matches(@"^[a-zA-Z\s]*$")
            .WithMessage("O campo ContactName deve conter apenas letras e espaços.")
            .NotNull()
            .WithMessage("O campo ContactName não pode ser nulo.");
        }
    }
}

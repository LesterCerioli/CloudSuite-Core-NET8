using CloudSuite.Modules.Application.Handlers.Country.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Country
{
    public class CheckCountryExistsByCountryNameRequestValidation : AbstractValidator<CheckCountryExistsByCountryNameRequest>
    {
        public CheckCountryExistsByCountryNameRequestValidation()
        {
            RuleFor(a => a.CountryName)
                .NotEmpty()
                .WithMessage("O campo CountryName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo CountryName deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CountryName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CountryName não pode ser nulo.");
        }
    }
}

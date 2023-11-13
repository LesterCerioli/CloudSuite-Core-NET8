using CloudSuite.Modules.Application.Hadlers.City;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.City
{
    public class CreateCityCommandValidation : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidation() 
        {
            RuleFor(a => a.CityName)
                .NotEmpty()
                .WithMessage("O campo CityName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo CityName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CityName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CityName não pode ser nulo.");

            RuleFor(a => a.State.StateName)
              .NotEmpty()
              .WithMessage("O campo StateName é obrigatório.")
              .Length(1, 100)
              .WithMessage("O campo StateName deve ter entre 1 e 100 caracteres.")
              .Matches(@"^[a-zA-Z\s]*$")
              .WithMessage("O campo StateName deve conter apenas letras e espaços.")
              .NotNull()
              .WithMessage("O campo StateName não pode ser nulo.");

            RuleFor(a => a.State.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");

            RuleFor(a => a.State.Country.CountryName)
                .NotEmpty()
                .WithMessage("O campo CountryName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo CountryName deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CountryName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CountryName não pode ser nulo.");

            RuleFor(a => a.State.Country.Code3)
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

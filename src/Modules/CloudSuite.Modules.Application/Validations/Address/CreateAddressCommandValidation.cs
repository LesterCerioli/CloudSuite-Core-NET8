using CloudSuite.Modules.Application.Hadlers.Address;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Address
{
    public  class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidation() 
        {

            RuleFor(a => a.ContactName)
                .NotEmpty()
                .WithMessage("O campo ContactName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo ContactName deve ter entre 1 e 60 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo ContactName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo ContactName não pode ser nulo.");

            RuleFor(a => a.AddressLine1)
                .NotEmpty()
                .WithMessage("O campo AddressLine1 é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo AddressLine1 deve ter entre 1 e 300 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo AddressLine1 deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo AddressLine1 não pode ser nulo.");

            RuleFor(a => a.City.CityName)
                .NotEmpty()
                .WithMessage("O campo CityName é obrigatório.")
                .Length(1, 50)
                .WithMessage("O campo CityName deve ter entre 1 e 50 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CityName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CityName não pode ser nulo.");


            RuleFor(a => a.District.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Name deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Name não pode ser nulo.");

            RuleFor(a => a.District.Type)
                .NotEmpty()
                .WithMessage("O campo Type é obrigatório.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Type deve conter apenas letras e espaços.")
                .NotNull().WithMessage("O campo Type não pode ser nulo.");

            RuleFor(a => a.District.Location)
                .NotEmpty()
                .WithMessage("O campo Location é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo Location deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo Location deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo Location não pode ser nulo.");

            RuleFor(a => a.District.State.StateName)
                .NotEmpty()
                .WithMessage("O campo StateName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo StateName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo StateName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo StateName não pode ser nulo.");

            RuleFor(a => a.District.State.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");

            RuleFor(a => a.District.State.Country.CountryName)
                .NotEmpty()
                .WithMessage("O campo CountryName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo CountryName deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CountryName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CountryName não pode ser nulo.");

            RuleFor(a => a.District.State.Country.Code3)
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

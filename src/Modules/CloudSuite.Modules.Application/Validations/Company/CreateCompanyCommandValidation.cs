using CloudSuite.Modules.Application.Handlers.Company;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Company
{
    public class CreateCompanyCommandValidation : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidation() 
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

            RuleFor(a => a.RegisterName)
                .NotEmpty()
                .WithMessage("O campo RegisterName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo RegisterName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo RegisterName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo RegisterName não pode ser nulo.");

            RuleFor(a => a.Address.ContactName)
              .NotEmpty()
              .WithMessage("O campo ContactName é obrigatório.")
              .Length(1, 60)
              .WithMessage("O campo ContactName deve ter entre 1 e 60 caracteres.")
              .Matches(@"^[a-zA-Z\s]*$")
              .WithMessage("O campo ContactName deve conter apenas letras e espaços.")
              .NotNull()
              .WithMessage("O campo ContactName não pode ser nulo.");

            RuleFor(a => a.Address.AddressLine1)
                .NotEmpty()
                .WithMessage("O campo AddressLine1 é obrigatório.")
                .Length(1, 300)
                .WithMessage("O campo AddressLine1 deve ter entre 1 e 300 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo AddressLine1 deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo AddressLine1 não pode ser nulo.");

            RuleFor(a => a.Address.City.CityName)
                .NotEmpty()
                .WithMessage("O campo CityName é obrigatório.")
                .Length(1, 50)
                .WithMessage("O campo CityName deve ter entre 1 e 50 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CityName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CityName não pode ser nulo.");


            RuleFor(a => a.Address.District.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Name deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Name não pode ser nulo.");

            RuleFor(a => a.Address.District.Type)
                .NotEmpty()
                .WithMessage("O campo Type é obrigatório.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Type deve conter apenas letras e espaços.")
                .NotNull().WithMessage("O campo Type não pode ser nulo.");

            RuleFor(a => a.Address.District.Location)
                .NotEmpty()
                .WithMessage("O campo Location é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo Location deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo Location deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo Location não pode ser nulo.");

            RuleFor(a => a.Address.District.State.StateName)
                .NotEmpty()
                .WithMessage("O campo StateName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo StateName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo StateName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo StateName não pode ser nulo.");

            RuleFor(a => a.Address.District.State.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");

            RuleFor(a => a.Address.District.State.Country.CountryName)
                .NotEmpty()
                .WithMessage("O campo CountryName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo CountryName deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo CountryName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo CountryName não pode ser nulo.");

            RuleFor(a => a.Address.District.State.Country.Code3)
                .NotEmpty()
                .WithMessage("O campo Code3 é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Code3 deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z0-9]*$")
                .WithMessage("O campo Code3 deve conter apenas letras e números.")
                .NotNull()
                .WithMessage("O campo Code3 não pode ser nulo.");

                RuleFor(a => a.Cnpj)
                    .Must(cnpj => IsValid(cnpj.CnpjNumber))
                    .WithMessage("O campo Cnpj é inválido.");


          
        }
        
            private bool IsValid(string cnpj)
            {
                if (string.IsNullOrWhiteSpace(cnpj))
                    return false;

                // Remove non-digit characters
                cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

                // CNPJ must have 14 digits
                if (cnpj.Length != 14)
                    return false;

                // Check for repeated digits or invalid checksum
                if (IsRepeatedDigits(cnpj) || !IsValidChecksum(cnpj))
                    return false;

                return true;
            }

            private bool IsRepeatedDigits(string cnpjNumber)
            {
                return cnpjNumber == new string(cnpjNumber[0], 14);
            }

        // Private method to validate the CNPJ checksum
        private bool IsValidChecksum(string cnpjNumber)
        {
            var sum = 0;
            var multiplier = 5;

            // Calculate the first checksum digit
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 6;

            // Calculate the second checksum digit
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Compare the calculated checksum digits with the provided ones
            return (int.Parse(cnpjNumber[12].ToString()) == digit1) && (int.Parse(cnpjNumber[13].ToString()) == digit2);
        }
    }
}


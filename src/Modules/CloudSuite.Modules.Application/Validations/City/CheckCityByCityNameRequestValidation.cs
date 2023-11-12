using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Hadlers.City.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.City
{
    public class CheckCityByCityNameRequestValidation : AbstractValidator<CheckCityExistsByCityNameRequest>
    {
        public CheckCityByCityNameRequestValidation() 
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
        }
    }
}

using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.PasswordGeneratorContext
{
    public class CheckPasswordExistsBySenhaRequestValidation : AbstractValidator<CheckPasswordExistsBySenhaRequest>
    {
        public CheckPasswordExistsBySenhaRequestValidation()
        {
           
            RuleFor(request => request.Senha)
                .NotEmpty().WithMessage("Password must be provided.")
                .Length(24).WithMessage("Password must be contain 24 characters long.");
        }
    }
}

using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.PasswordGeneratorContext
{
    public class CreatePasswordCommandValidation : AbstractValidator<CreatePasswordCommand>
    {
        public CreatePasswordCommandValidation()
        {
            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Password must be provided.")
                .MinimumLength(24).WithMessage("Password must be at least 24 characters long.")
                .Matches(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^a-zA-Z0-9\s]).{24,}$")
                .WithMessage("Password must contain at least one letter, one number, and one special character.");

            RuleFor(c => c.CaracterNumber)
                .NotEmpty().WithMessage("Number of characters in the password must be provided.")
                .GreaterThanOrEqualTo(24).WithMessage("Password must be at least 24 characters long.")
                .LessThanOrEqualTo(100).WithMessage("Password cannot be more than 100 characters long.")
                .Must(BeValidInteger).WithMessage("Number of characters in the password must be a valid integer.");
        }

        private bool BeValidInteger(int? nullable)
        {
            throw new NotImplementedException();
        }

        private bool BeValidInteger(int value)
        {
            return value >= 24; // Customize this according to your requirements
        }
    }
}

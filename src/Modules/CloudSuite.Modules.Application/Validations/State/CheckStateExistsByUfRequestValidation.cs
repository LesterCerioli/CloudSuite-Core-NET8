using CloudSuite.Modules.Application.Handlers.State.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.State
{
    public class CheckStateExistsByUfRequestValidation : AbstractValidator<CheckStateExistsByUfRequest>
    {
        public CheckStateExistsByUfRequestValidation ()
        {
            RuleFor(a => a.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");
        }
    }
}

using CloudSuite.Modules.Application.Handlers.Media.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Media
{
    public class CheckMediaExistsByFileSizeRequestValidation : AbstractValidator<CheckMediaExistsByFileSizeRequest>
    {
        public CheckMediaExistsByFileSizeRequestValidation()
        {
            RuleFor(a => a.FileSize)
                .NotNull()
                .WithMessage("O campo FileSize é obrigatório.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("O campo FileSize deve ser maior ou igual a 0.");
        }
    }
}

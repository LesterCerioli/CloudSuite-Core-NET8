using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Vendor
{
    public class CheckVendorExistsByNameRequestValidation : AbstractValidator<CheckVendorExistsByNameRequest>
    {
        public CheckVendorExistsByNameRequestValidation() 
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .WithMessage("O campo Name é obrigatório.")
               .Length(1, 450)
               .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Name deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Name não pode ser nulo.");
        }
    }
}

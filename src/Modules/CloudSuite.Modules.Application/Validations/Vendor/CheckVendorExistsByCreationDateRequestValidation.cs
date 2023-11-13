using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Vendor
{
    public class CheckVendorExistsByCreationDateRequestValidation : AbstractValidator<CheckVendorExistsByCreationDateRequest>
    {
        public CheckVendorExistsByCreationDateRequestValidation()
        {
            RuleFor(a => a.CreatedOn)
                .NotEmpty()
                .WithMessage("O campo CreatedOn é obrigatório.")
                .NotNull()
                .WithMessage("O campo CreatedOn não pode ser nulo.");
        }
    }
}

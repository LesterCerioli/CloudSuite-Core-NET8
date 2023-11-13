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
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("O campo CreatedOn deve ser uma data e hora no passado ou presente.");

        }
    }
}

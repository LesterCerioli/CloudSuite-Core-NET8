using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Vendor
{
    public class CheckVendorExistsByCreationDateRequestValidation : AbstractValidator<CheckVendorExistsByCreatedOnRequest>
    {
        public CheckVendorExistsByCreationDateRequestValidation()
        {
            RuleFor(a => a.CreatedOn)
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("O campo CreatedOn deve ser uma data e hora no passado ou presente.");

        }
    }
}

using CloudSuite.Modules.Application.Handlers.Company.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Company
{
    public class CheckCompanyExistsByCnpjRequestValidation : AbstractValidator<CheckCompanyExistsByCnpjRequest>
    {
        public CheckCompanyExistsByCnpjRequestValidation()
        {
            RuleFor(a => a.Cnpj)
                .Must(cnpj => cnpj.IsValid(cnpj.CnpjNumber))
                .WithMessage("O campo Cnpj é inválido.");
        }
    }
}

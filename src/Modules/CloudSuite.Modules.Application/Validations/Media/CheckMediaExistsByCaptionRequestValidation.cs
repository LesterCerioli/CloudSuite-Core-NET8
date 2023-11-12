using CloudSuite.Modules.Application.Handlers.Media.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Media
{
    public class CheckMediaExistsByCaptionRequestValidation : AbstractValidator<CheckMediaExistsByCaptionRequest>
    {
        public CheckMediaExistsByCaptionRequestValidation() 
        {
            RuleFor(a => a.Caption)
                .NotEmpty()
                .WithMessage("O campo Caption é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Caption deve ter entre 1 e 450 caracteres.");
        }
    }
}

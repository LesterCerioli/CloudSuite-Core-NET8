using CloudSuite.Modules.Application.Handlers.Email;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Email
{
    public class CreateEmailCommandValidation : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidation() 
        {
            RuleFor(a => a.Subject)
                .Length(1, 450)
                .WithMessage("O campo Subject deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Body)
                .NotEmpty()
                .WithMessage("O campo Body é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Body deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Sender)
                .NotEmpty()
                .WithMessage("O campo Sender é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Sender deve ser um endereço de email válido.");

            RuleFor(a => a.Recipient)
                .NotEmpty()
                .WithMessage("O campo Recipient é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Recipient deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Recipient deve ser um endereço de email válido.");

            
        }
    }
}

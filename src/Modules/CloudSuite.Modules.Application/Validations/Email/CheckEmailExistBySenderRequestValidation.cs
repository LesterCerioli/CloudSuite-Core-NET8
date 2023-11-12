﻿using CloudSuite.Modules.Application.Handlers.Email.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.Email
{
    public class CheckEmailExistBySenderRequestValidation : AbstractValidator<CheckEmailExistBySenderRequest>
    {
        public CheckEmailExistBySenderRequestValidation() 
        {
            RuleFor(a => a.Sender)
                .NotEmpty()
                .WithMessage("O campo Sender é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Sender deve ser um endereço de email válido.");
        }
    }
}
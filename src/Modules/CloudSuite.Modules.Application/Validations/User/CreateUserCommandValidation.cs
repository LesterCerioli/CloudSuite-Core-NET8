using CloudSuite.Modules.Application.Handlers.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.User
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation() 
        {
            RuleFor(a => a.FullName)
               .NotEmpty()
               .WithMessage("O campo FullName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo FullName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo FullName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo FullName não pode ser nulo.");

            RuleFor(a => a.Email.Subject)
                .Length(1, 450)
                .WithMessage("O campo Subject deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Email.Body)
                .NotEmpty()
                .WithMessage("O campo Body é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Body deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Email.Sender)
                .NotEmpty()
                .WithMessage("O campo Sender é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Sender deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Sender deve ser um endereço de email válido.");

            RuleFor(a => a.Email.Recipient)
                .NotEmpty()
                .WithMessage("O campo Recipient é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Recipient deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Recipient deve ser um endereço de email válido.");

             RuleFor(a => a.Email.SentDate)
                .GreaterThan(DateTimeOffset.Now)
                .WithMessage("A data deve estar no futuro.");

            RuleFor(a => a.Email.CodeErrorEmail)
                .IsInEnum()
                .WithMessage("O campo CodeErrorEmail deve ser um valor válido do enum CodeErrorEmail.");

            RuleFor(a => a.Telephone.TelephoneNumber)
                .NotEmpty()
                .WithMessage("O preenchimento do telefone é obrigatorio")
                .Length(10, 13)
                .WithMessage("O número de telefone deve ter entre 10 e 13 caracteres.")
                .Matches(@"^[0-9a-zA-Z\s]*$")
                .WithMessage("O número de telefone deve conter apenas números e letras.")
                .NotNull()
                .WithMessage("O número de telefone não pode ser nulo.");

            RuleFor(a => a.Telephone.TelephoneRegion)
               .Length(1, 100)
               .WithMessage("O campo TelephoneRegion deve ter entre 1 e 100 caracteres.");

            RuleFor(a => a.Vendor.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Name deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Name não pode ser nulo.");

            RuleFor(a => a.Vendor.Slug)
               .NotEmpty()
               .WithMessage("O campo Slug é obrigatório.")
               .Length(1, 450)
               .WithMessage("O campo Slug deve ter entre 1 e 450 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Slug deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Slug não pode ser nulo.");

            RuleFor(a => a.Vendor.Description)
               .NotEmpty()
               .WithMessage("O campo Description é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo Description deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Description deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Description não pode ser nulo.");

            RuleFor(a => a.CreatedOn)
                .NotEmpty()
                .WithMessage("O campo CreatedOn é obrigatório.")
                .NotNull()
                .WithMessage("O campo CreatedOn não pode ser nulo.");

            RuleFor(a => a.LatestUpdatedOn)
               .NotEmpty()
               .WithMessage("O campo LatestUpdatedOn é obrigatório.")
               .NotNull()
               .WithMessage("O campo LatestUpdatedOn não pode ser nulo.");

            RuleFor(a => a.RefreshTokenHash)
                .NotEmpty()
                .WithMessage("O campo RefreshTokenHash é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo RefreshTokenHash deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo RefreshTokenHash deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo RefreshTokenHash não pode ser nulo.");

            RuleFor(a => a.Culture)
               .NotEmpty()
               .WithMessage("O campo Culture é obrigatório.")
               .Length(1, 450)
               .WithMessage("O campo Culture deve ter entre 1 e 450 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Culture deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Culture não pode ser nulo.");

            RuleFor(a => a.ExtensionData)
               .NotEmpty()
               .WithMessage("O campo ExtensionData é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo ExtensionData deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo ExtensionData deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo ExtensionData não pode ser nulo.");
        }
    }
}

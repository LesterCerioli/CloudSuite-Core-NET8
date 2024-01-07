using CloudSuite.Modules.Application.Handlers.District.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.District
{
    public class CheckDistrictExistsByNameRequestValidation : AbstractValidator<CheckDistrictExistsByNameRequest>
    {
        public CheckDistrictExistsByNameRequestValidation() 
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Type deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Name não pode ser nulo.");
        }
    }
}

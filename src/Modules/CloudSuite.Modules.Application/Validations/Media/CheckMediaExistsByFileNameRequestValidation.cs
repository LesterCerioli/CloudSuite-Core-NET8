using CloudSuite.Modules.Application.Handlers.Media.Request;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Media
{
    public class CheckMediaExistsByFileNameRequestValidation : AbstractValidator<CheckMediaExistsByFileNameRequest>
    {
        public CheckMediaExistsByFileNameRequestValidation() 
        {
            RuleFor(a => a.FileName)
                .NotEmpty()
                .WithMessage("O campo FileName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo FileName deve ter entre 1 e 450 caracteres.");
        }
    }
}

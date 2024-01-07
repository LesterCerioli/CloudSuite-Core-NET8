using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Email.Responses
{
    public class CreateEmailResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateEmailResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateEmailResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            this.AddError(falseValidation);
        }
    }
}

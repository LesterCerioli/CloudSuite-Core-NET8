using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Hadlers.Address.Responses
{
    public class CreateAddressResponse : Response
    {

            public Guid RequestId { get; private set; }

            public CreateAddressResponse(Guid requestId, ValidationResult result)
            {
                RequestId = requestId;

                foreach (var item in result.Errors)
                {
                    this.AddError(item.ErrorMessage);
                }
            }

            public CreateAddressResponse(Guid requestId, string falseValidation)
            {
                RequestId = requestId;
                this.AddError(falseValidation);
            }
    }
}

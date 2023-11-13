using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;


namespace CloudSuite.Modules.Application.Handlers.Country.Responses
{
    public class CheckCountryExistsByCountryNameResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckCountryExistsByCountryNameResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckCountryExistsByCountryNameResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falseValidation);
        }
    }
}

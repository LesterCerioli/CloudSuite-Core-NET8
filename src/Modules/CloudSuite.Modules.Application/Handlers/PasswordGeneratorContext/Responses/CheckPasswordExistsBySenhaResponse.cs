using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Responses
{
    public class CheckPasswordExistsBySenhaResponse : Response
    {
        private bool v;
        private object validationResult;

        public CheckPasswordExistsBySenhaResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckPasswordExistsBySenhaResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }

        public CheckPasswordExistsBySenhaResponse(object result, bool v, object validationResult) : base(result)
        {
            this.v = v;
            this.validationResult = validationResult;
        }

        public Guid RequestId { get; private set; }

        public bool? Exists { get; set; }
    }
}

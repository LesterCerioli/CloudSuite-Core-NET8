﻿using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Responses
{
    public class CheckVendorExistsByNameResponse : Response
    {
        public  Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckVendorExistsByNameResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
    }

    public CheckVendorExistsByNameResponse(Guid requestId, string falseValidation)
    {
        RequestId = requestId;
        Exists = false;
        this.AddError(falseValidation);
    }
}
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Hadlers.AppSetting.Request
{
    public class CheckAppSettingExistsByValueRequest : IRequest<CheckAppSettingByValueResponse>
    {
        public Guid Id { get; private set; }

        public string? Value { get; private set; }

        public CheckAppSettingExistsByValueRequest(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }

        public CheckAppSettingExistsByValueRequest() { }
    }
}

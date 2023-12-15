using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Hadlers.AppSetting;
using CloudSuite.Modules.Application.Handlers.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IAppSetinggAppService
    {
        //ainda não foi criada a ViewModel do appsetting

        //Task<AppSettingViewModel> GetByValue(string value);

        //Task<AppSettingViewModel> GetByModule(string module);

        Task Save(CreateAppSettingCommand commandCreate);
    }
}

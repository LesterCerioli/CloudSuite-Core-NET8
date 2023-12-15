using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.AppSetting;
using CloudSuite.Modules.Application.Handlers.Email;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class AppSetinggAppService : IAppSetinggAppService
    {
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AppSetinggAppService(IAppSettingRepository appSettingRepository, IMapper mapper, ILogger logger)
        {
            _appSettingRepository = appSettingRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /*
        public async Task<AppSettingViewModel> GetByValue(string value)
        {
            return _mapper.Map<AppSettingViewModel>(await _appSettingRepository.GetByValue(value));
        }

        public async Task<AppSettingViewModel> GetByModule(string module)
        {
            return _mapper.Map<AppSettingViewModel>(await _appSettingRepository.GetByModule(module));
        }
        */
        //ainda faltam a view model do appsetting

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateAppSettingCommand commandCreate)
        {
            await _appSettingRepository.Add(commandCreate.GetEntity());
        }
    }
}

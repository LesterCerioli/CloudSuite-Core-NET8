using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface IAppSettingRepository
    {
        Task<AppSetting> GetByValue(string value);

        Task<AppSetting> GetByModule(string module);

        Task<IEnumerable<AppSetting>> GetAll();

        Task Add(AppSetting appSetting);

        void Update(AppSetting appSetting);

        void Remove(AppSetting appSetting);
    }
}
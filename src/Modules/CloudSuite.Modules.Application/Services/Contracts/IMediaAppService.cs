using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IMediaAppService
    {
        Task<MediaViewModel> GetByFileName(string fileName);

        Task<MediaViewModel> GetByFileSize(int? fileSize);

        Task Save(CreateMediaCommand commandCreate);

	}
}
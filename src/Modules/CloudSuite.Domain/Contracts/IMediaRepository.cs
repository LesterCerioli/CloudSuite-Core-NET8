using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface IMediaRepository
    {
        Task<Media> GetByCaption(string caption);

        Task<Media> GetByFileName(string fileName);

        Task<Media> GetByFileSize(int? fileSize);

        Task<IEnumerable<Media>> GetList();

        Task Add(Media media);

        void Update(Media media);

        void Remove(Media media);
    }
}
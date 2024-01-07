using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface IEmailRepository
    {
        Task<Email> GetBySender(string sender);

        Task<Email> GetByRecipient(string recipient);

        Task<Email> GetByCodeErrorEmail(CodeErrorEmail codeErrorEmail);

        Task<IEnumerable<Email>> GetList();

        Task Add(Email email);

        void Update(Email email);

        void Remove(Email email);

         
    }
}
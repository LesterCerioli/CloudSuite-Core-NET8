using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public Task Add(Email email)
        {
            throw new NotImplementedException();
        }

        public Task<Email> GetByCodeErrorEmail(CodeErrorEmail codeErrorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Email> GetByRecipient(string recipient)
        {
            throw new NotImplementedException();
        }

        public Task<Email> GetBySender(string sender)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Email>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Email email)
        {
            throw new NotImplementedException();
        }

        public void Update(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
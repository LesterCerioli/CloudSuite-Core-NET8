using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        protected readonly DbSet<Email> DbSet;
        protected readonly CoreDbContext Db;
        
        public EmailRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Emails; 
        }
        public async Task Add(Email email)
        {
            await Task.Run(() => { 
                DbSet.Add(email);
                Db.SaveChanges();
            });
            
        }

        public async Task<Email> GetByCodeErrorEmail(CodeErrorEmail codeErrorEmail)
        {
            return DbSet.FirstOrDefault(a => a.CodeErrorEmail == codeErrorEmail);
        }

        public async Task<Email> GetByRecipient(string recipient)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Recipient == recipient);
            
        }

        public async Task<Email> GetBySender(string sender)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Sender == sender);
        }

        public async Task<IEnumerable<Email>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Email email)
        {
            DbSet.Remove(email);
        }

        public void Update(Email email)
        {
            DbSet.Update(email);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
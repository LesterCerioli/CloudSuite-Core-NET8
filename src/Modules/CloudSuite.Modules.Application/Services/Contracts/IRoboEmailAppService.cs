using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Email;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IRoboEmailAppService
    {
        Task<EmailViewModel> GetBySender(string sender);

        Task<EmailViewModel> GetByRecipient(string recipient);

        Task<EmailViewModel> GetByCodeErrorEmail(CodeErrorEmail codeErrorEmail);

        Task Save(CreateEmailCommand commandCreate);
    }
}
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IUserAppService
    {
		Task<UserViewModel> GetByEmail(Email email);

		Task<UserViewModel> GetByCpf(Cpf cpf);

		Task Save(CreateUserCommand commandCreate);

	}
}
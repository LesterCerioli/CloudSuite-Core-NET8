using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext;
using CloudSuite.Modules.Application.ViewModels.PasswordGeneratorContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.PasswirdGeneratorContext
{
	public interface IPasswordAppService
	{
		Task<PasswordViewModel> GetBySecret(string senha);

		Task SaveAsync(CreatePasswordCommand commandCreate);
    }
}

using AutoMapper;
using CloudSuite.Domain.Contracts.PasswordGeneratorContext;
using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext;
using CloudSuite.Modules.Application.Services.Contracts.PasswirdGeneratorContext;
using CloudSuite.Modules.Application.ViewModels.PasswordGeneratorContext;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.PasswordGeneratorContext
{
    public class PasswordAppService : IPasswordAppService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly IPasswordRepository _passwordRepository;

        public PasswordAppService(
            IPasswordRepository  passwordRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _passwordRepository = passwordRepository;
        }
        public async Task<PasswordViewModel> GetBySecret(string senha)
        {
            return _mapper.Map<PasswordViewModel>(await _passwordRepository.GetBySecret(senha));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CreatePasswordCommand commandCreate)
        {
            await _passwordRepository.Add(commandCreate.GetEntity());
        }
    }
}

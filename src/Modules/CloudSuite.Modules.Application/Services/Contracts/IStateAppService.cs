using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IStateAppService
    {
        Task<StateViewModel> GetByName(string stateName);

        Task<StateViewModel> GetByUF(string uf);

        Task Save(CreateStateCommand commandCreate);
    }
}

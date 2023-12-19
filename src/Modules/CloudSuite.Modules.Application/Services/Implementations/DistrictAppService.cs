using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class DistrictAppService : IDistrictAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public DistrictAppService(IDistrictRepository districtRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<DistrictViewModel> GetByName(string name)
        {
            return _mapper.Map<DistrictViewModel>(await _districtRepository.GetByName(name));
        }

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateDistrictCommand commandCreate)
        {
            await _districtRepository.Add(commandCreate.GetEntity());
        }
    }
}
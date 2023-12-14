using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class DistrictAppService : IDistrictAppService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DistrictAppService(IDistrictRepository districtRepository, IMapper mapper, ILogger logger)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
            _logger = logger;
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
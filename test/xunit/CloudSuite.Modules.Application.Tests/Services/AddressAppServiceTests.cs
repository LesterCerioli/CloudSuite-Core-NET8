using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class AddressAppServiceTests
    {

        public async Task GetByAddressLine1_ShouldReturnsCompanyViewModel(string addressLine, string contactName)
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var tomadorServicoAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object);
        }
    }
}

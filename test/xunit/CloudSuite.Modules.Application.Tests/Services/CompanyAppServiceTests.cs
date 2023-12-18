using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Services.Implementations;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CompanyAppServiceTests
    {
        [Theory]
        [InlineData("30.330.637/0001-07")]
        [InlineData("02.852.343/0001-00")]
        [InlineData("56.017.210/0001-47")]
        public async Task GetByCnpj_ShouldReturnsCompanyViewModel(string cnpj)
        {
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object);

            var companyEntity = new Company(Guid.NewGuid(), new Cnpj(cnpj), )
        }

        public async Task GetByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {

        }


        public async Task GetByCnpj_ShouldHandleInvalidMappingResultt(string cnpj)
        {

        }


    }
}

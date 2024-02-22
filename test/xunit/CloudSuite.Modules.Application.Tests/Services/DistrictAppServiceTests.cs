using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class DistrictAppServiceTests
    {
        [Theory]
        [InlineData("district1", "type1", "location1834")]
        [InlineData("district1", "type2", "location256")]
        [InlineData("district1", "type3", "location356")]
        public async Task GetByName_ShouldReturnsCompanyViewModel(string? name, string? type, string? location)
        {
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var districtEntity = new District(name, type, location);

            districtRepositoryMock.Setup(repo => repo.GetByName(name)).ReturnsAsync(districtEntity);

            var expectedViewModel = new DistrictViewModel()
            {
                Id = districtEntity.Id,
                Name = name,
                Type = type,
                Location = location
            };

            mapperMock.Setup(mapper => mapper.Map<DistrictViewModel>(districtEntity)).Returns(expectedViewModel);

            // Act
            var result = await districtAppService.GetByName(name);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("district3")]
        [InlineData("district4")]
        [InlineData("district5")]
        public async Task GetByName_ShouldHandleNullRepositoryResult(string name)
        {
            // Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            districtRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>()))
                .ReturnsAsync((District)null); // Simulate null result from the repository

            // Act
            var result = await districtAppService.GetByName(name);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("zimbabue")]
        [InlineData("ongobongo")]
        [InlineData("xerem")]
        public async Task GetByName_ShouldHandleInvalidMappingResult(string countryName)
        {
            // Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            districtRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => districtAppService.GetByName(countryName));
        }

        [Theory]
        [InlineData("piabeta", "type4", "location164")]
        [InlineData("cambuci", "type5", "location2123")]
        [InlineData("parada angelica", "type6", "location323")]
        public async Task Save_ShouldAddCompanyToRepository(string? name, string? type, string? location)
        {
            // Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createDistrictCommand = new CreateDistrictCommand()
            {
                Name = name,
                Type = type,
                Location = location
            };

            // Act
            await districtAppService.Save(createDistrictCommand);

            // Assert
            districtRepositoryMock.Verify(repo => repo.Add(It.IsAny<District>()), Times.Once);
        }

        [Theory]
        [InlineData("santo amaro", "type7", "location1")]
        [InlineData("penha", "type8", "location2")]
        [InlineData("jacare", "type9", "location3")]
        public async Task Save_ShouldHandleNullRepositoryResult(string? name, string? type, string? location)
        {
            //Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createDistrictCommand = new CreateDistrictCommand()
            {
                Name = name,
                Type = type,
                Location = location
            };

            districtRepositoryMock.Setup(repo => repo.Add(It.IsAny<District>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => districtAppService.Save(createDistrictCommand));

        }

        [Theory]
        [InlineData("cidade de deus", "type10", "location10")]
        [InlineData("district11", "type20", "location20")]
        [InlineData("district2", "type30", "location30")]
        public async Task Save_ShouldHandleInvalidMappingResult(string? name, string? type, string? location)
        {

            //Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var districtAppService = new DistrictAppService(
                districtRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createDistrictCommand = new CreateDistrictCommand()
            {
                Name = name,
                Type = type,
                Location = location
            };

            // Act       
            districtRepositoryMock.Setup(repo => repo.Add(It.IsAny<District>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => districtAppService.Save(createDistrictCommand));
        }

    }
}

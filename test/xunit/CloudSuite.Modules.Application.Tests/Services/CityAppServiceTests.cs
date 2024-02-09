using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModel;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CityAppServiceTests
    {
        [Theory]
        [InlineData("Salvador", "Bahia")]
        [InlineData("São Paulo", "São Paulo")]
        [InlineData("Rio de Janeiro", "Rio de Janeiro")]
        public async Task GetByCityName_ShouldReturnsCompanyViewModel(string cityname, string statename)
        {
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );
            var country = new Country("Brazil", "BRA", true, true, true, true, true);
            var state = new State("Ba", "Bahia", country, country.Id);


            var cityEntity = new City(cityname, state);

            cityRepositoryMock.Setup(repo => repo.GetByCityName(cityname)).ReturnsAsync(cityEntity);

            var expectedViewModel = new CityViewModel()
            {
                Id = cityEntity.Id,
                CityName = cityname,
                State = statename
            };

            mapperMock.Setup(mapper => mapper.Map<CityViewModel>(cityEntity)).Returns(expectedViewModel);

            // Act
            var result = await cityAppService.GetByCityName(cityname);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }


        [Theory]
        [InlineData("Belém")]
        [InlineData("Fortaleza")]
        [InlineData("Natal")]
        public async Task GetByCityName_ShouldHandleNullRepositoryResult(string cityname)
        {
            // Arrange
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            cityRepositoryMock.Setup(repo => repo.GetByCityName(It.IsAny<string>()))
                .ReturnsAsync((City)null); // Simulate null result from the repository

            // Act
            var result = await cityAppService.GetByCityName(cityname);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Maceio")]
        [InlineData("Aracaju")]
        [InlineData("Maranhão")]
        public async Task GetByCityName_ShouldHandleInvalidMappingResult(string cityname)
        {
            // Arrange
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            cityRepositoryMock.Setup(repo => repo.GetByCityName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => cityAppService.GetByCityName(cityname));
        }

        [Theory]
        [InlineData("Arraial do cabo", "Rio de janeiro")]
        [InlineData("São bernardo", "São Paulo")]
        [InlineData("Cabo frio", "Rio de Janeiro")]
        public async Task Save_ShouldAddCompanyToRepository(string cityname, string statename)
        {
            // Arrange
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createCityCommand = new CreateCityCommand()
            {
               

            };

            // Act
            await cityAppService.Save(createCityCommand);

            // Assert
            cityRepositoryMock.Verify(repo => repo.Add(It.IsAny<City>()), Times.Once);
        }

        [Theory]
        [InlineData("Praia do forte", "Bahia")]
        [InlineData("Guapamirim", "São Paulo")]
        [InlineData("Duque de caxias", "Rio de Janeiro")]
        public async Task Save_ShouldHandleNullRepositoryResult(string cityname, string statename)
        {
            //Arrange
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createCityCommand = new CreateCityCommand()
            {


            };

            cityRepositoryMock.Setup(repo => repo.Add(It.IsAny<City>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => cityAppService.Save(createCityCommand));

        }

        [Theory]
        [InlineData("Salvador", "Bahia")]
        [InlineData("São Paulo", "São Paulo")]
        [InlineData("Rio de Janeiro", "Rio de Janeiro")]
        public async Task Save_ShouldHandleInvalidMappingResult(string cityname, string statename)
        {

            //Arrange
            var cityRepositoryMock = new Mock<ICityRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var cityAppService = new CityAppService(
                cityRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createCityCommand = new CreateCityCommand()
            {


            };

            // Act       
            cityRepositoryMock.Setup(repo => repo.Add(It.IsAny<City>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => cityAppService.Save(createCityCommand));
        }


    }
}

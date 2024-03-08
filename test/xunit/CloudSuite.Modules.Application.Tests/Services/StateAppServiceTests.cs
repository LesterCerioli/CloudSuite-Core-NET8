using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Email;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class StateAppServiceTests
    {
        [Theory]
        [InlineData("ba", "Bahia")]
        [InlineData("es", "espirito santo")]
        [InlineData("sc", "santa catarina")]
        public async Task GetByName_ShouldReturnsCompanyViewModel(string uf, string stateName)
        {
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var country = new Country(Guid.NewGuid(), "Brazil", "BRA", true, true, true, true, true);

            var stateEntity = new State(Guid.NewGuid(), uf, stateName, country, country.Id);

            stateRepositoryMock.Setup(repo => repo.GetByName(stateName)).ReturnsAsync(stateEntity);


            var expectedViewModel = new StateViewModel()
            {
                Id = stateEntity.Id,
                StateName = stateName,
                UF = uf,
                Country = country.CountryName
            };

            mapperMock.Setup(mapper => mapper.Map<StateViewModel>(stateEntity)).Returns(expectedViewModel);

            // Act
            var result = await mediaAppService.GetByName(stateName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Sergipe")]
        [InlineData("Ceara")]
        [InlineData("Pernambuco")]
        public async Task GetByName_ShouldHandleNullRepositoryResult(string name)
        {
            // Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            stateRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>())).ReturnsAsync((State)null); // Simulate null result from the repository

            // Act
            var result = await stateAppService.GetByName(name);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Rio Grande do Norte")]
        [InlineData("Paraiba")]
        [InlineData("Amazonas")]
        public async Task GetByName_ShouldHandleInvalidMappingResult(string name)
        {
            // Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            stateRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateAppService.GetByName(name));
        }

        [Theory]
        [InlineData("PA", "Para")]
        [InlineData("DF", "Distrito federal")]
        [InlineData("PR", "Parana")]
        public async Task GetByUF_ShouldReturnsCompanyViewModel(string uf, string stateName)
        {
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var country = new Country(Guid.NewGuid(), "Brazil", "BRA", true, true, true, true, true);

            var stateEntity = new State(Guid.NewGuid(), uf, stateName, country, country.Id);

            stateRepositoryMock.Setup(repo => repo.GetByUF(uf)).ReturnsAsync(stateEntity);


            var expectedViewModel = new StateViewModel()
            {
                Id = stateEntity.Id,
                StateName = stateName,
                UF = uf,
                Country = country.CountryName
            };

            mapperMock.Setup(mapper => mapper.Map<StateViewModel>(stateEntity)).Returns(expectedViewModel);

            // Act
            var result = await mediaAppService.GetByUF(uf);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("DF")]
        [InlineData("AC")]
        [InlineData("AM")]
        public async Task GetByUF_ShouldHandleNullRepositoryResult(string uf)
        {
            // Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            stateRepositoryMock.Setup(repo => repo.GetByUF(It.IsAny<string>())).ReturnsAsync((State)null); // Simulate null result from the repository

            // Act
            var result = await stateAppService.GetByUF(uf);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("SC")]
        [InlineData("RS")]
        [InlineData("PB")]
        public async Task GetByUF_ShouldHandleInvalidMappingResult(string uf)
        {
            // Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            stateRepositoryMock.Setup(repo => repo.GetByUF(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateAppService.GetByUF(uf));
        }

        [Theory]
        [InlineData("PA", "Pernambuco")]
        [InlineData("DF", "Rio grande Sul")]
        [InlineData("PA", "Para")]
        public async Task Save_ShouldAddCompanyToRepository(string uf, string stateName)
        {
            // Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createStateCommand = new CreateStateCommand()
            {


            };

            // Act
            await stateAppService.Save(createStateCommand);

            // Assert
            stateRepositoryMock.Verify(repo => repo.Add(It.IsAny<State>()), Times.Once);
        }

        [Theory]
        [InlineData("PA", "Para")]
        [InlineData("DF", "Distrito federal")]
        [InlineData("PR", "Parana")]
        public async Task Save_ShouldHandleNullRepositoryResult(string uf, string stateName)
        {
            //Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createStateCommand = new CreateStateCommand()
            {


            };

            stateRepositoryMock.Setup(repo => repo.Add(It.IsAny<State>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => stateAppService.Save(createStateCommand));

        }

        [Theory]
        [InlineData("ba", "Bahia")]
        [InlineData("es", "espirito santo")]
        [InlineData("sc", "santa catarina")]
        public async Task Save_ShouldHandleInvalidMappingResult(string uf, string stateName)
        {

            //Arrange
            var stateRepositoryMock = new Mock<IStateRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var stateAppService = new StateAppService(
                stateRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createStateCommand = new CreateStateCommand()
            {


            };

            // Act       
            stateRepositoryMock.Setup(repo => repo.Add(It.IsAny<State>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => stateAppService.Save(createStateCommand));
        }

    }
}

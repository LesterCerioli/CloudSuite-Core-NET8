using AutoMapper;
using Moq;
using NetDevPack.Mediator;
using System.Threading.Tasks;
using System;
using Xunit;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.ViewModel;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Hadlers.Address;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
    public class AddressAppServiceTests
    {
        [Theory]
        [InlineData("Salvador", "district1", "igor moreira", "rua das flores")]
        [InlineData("Sao paulo", "district2", "Beltrão", "rua azul")]
        [InlineData("Fortaleza", "district3", "francisco coins", "rua twitch")]
        public async Task GetByContactName_ShouldReturnsCompanyViewModel(string city, string district, string contactName, string addressLine1)
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

                var country = new Country("Brazil", "BRA", true, true, true, true, true);
                var state = new State("Ba", "Bahia", country, country.Id);
                var districtentity = new District("fourteen district", "two", "location");
                var cityEntity = new City(state.Id,"são paulo", state);


            var addressEntity = new Address(cityEntity, districtentity, contactName, addressLine1);

            addressRepositoryMock.Setup(repo => repo.GetByContactName(contactName)).ReturnsAsync(addressEntity);

            var expectedViewModel = new AddressViewModel()
            {
                Id = addressEntity.Id,
                ContactName = contactName,
                AddressLine1 = addressLine1,
                City = city,
                District = district,
            };

            mapperMock.Setup(mapper => mapper.Map<AddressViewModel>(addressEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByContactName(contactName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("junior")]
        [InlineData("fabio")]
        [InlineData("luis")]
        public async Task GetByContactName_ShouldHandleNullRepositoryResult(string contactName)
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            addressRepositoryMock.Setup(repo => repo.GetByContactName(It.IsAny<string>()))
                .ReturnsAsync((Address)null); // Simulate null result from the repository

            // Act
            var result = await addressAppService.GetByContactName(contactName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("junior")]
        [InlineData("fabio")]
        [InlineData("luis")]
        public async Task GetByContactName_ShouldHandleInvalidMappingResult(string contactName)
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            addressRepositoryMock.Setup(repo => repo.GetByContactName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => addressAppService.GetByContactName(contactName));
        }

        [Theory]
        [InlineData("Manaus", "district4", "francisco moreira", "rua dos carros")]
        [InlineData("Belém", "district5", "casemiro", "rua dos prazeres")]
        [InlineData("Aracaju", "district6", "luisa sonza", "rua das acacias")]
        public async Task GetByAddressLine_ShouldReturnsCompanyViewModel(string city, string district, string contactName, string addressLine1)
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var country = new Country("Brazil", "BRA", true, true, true, true, true);
            var state = new State("Ba", "Bahia", country, country.Id);
            var districtentity = new District("fourteen district", "two", "location");
            var cityEntity = new City(state.Id, "são paulo", state);


            var addressEntity = new Address(cityEntity, districtentity, contactName, addressLine1);

            addressRepositoryMock.Setup(repo => repo.GetByAddressLine(addressLine1)).ReturnsAsync(addressEntity);

            var expectedViewModel = new AddressViewModel()
            {
                Id = addressEntity.Id,
                ContactName = contactName,
                AddressLine1 = addressLine1,
                City = city,
                District = district
            };

            mapperMock.Setup(mapper => mapper.Map<AddressViewModel>(addressEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByAddressLine(addressLine1);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Rua da Independência")]
        [InlineData("Rua José de Alencar")]
        [InlineData("Rua Amazonas")]
        public async Task GetByAddressLine_ShouldHandleNullRepositoryResult(string addressLine1)
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            addressRepositoryMock.Setup(repo => repo.GetByAddressLine(It.IsAny<string>()))
                .ReturnsAsync((Address)null); // Simulate null result from the repository

            // Act
            var result = await addressAppService.GetByAddressLine(addressLine1);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Rua Mahatma Gandhi")]
        [InlineData("Rua Martin Luther King")]
        [InlineData("Rua Nelson Mandela")]
        public async Task GetByAddressLine_ShouldHandleInvalidMappingResult(string addressLine1)
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            addressRepositoryMock.Setup(repo => repo.GetByAddressLine(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => addressAppService.GetByAddressLine(addressLine1));
        }

        [Theory]
        [InlineData("Salvador", "district1", "igor moreira", "rua das flores")]
        [InlineData("Sao paulo", "district2", "Beltrão", "rua azul")]
        [InlineData("Fortaleza", "district3", "francisco coins", "rua twitch")]
        public async Task Save_ShouldAddCompanyToRepository(string city, string district, string contactName, string addressLine1)
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var country = new Country("Brazil", "BRA", true, true, true, true, true);
            var state = new State("Ba", "Bahia", country, country.Id);
            var districtentity = new District("fourteen district", "two", "location");
            var cityEntity = new City(state.Id, "são paulo", state);


            var addressEntity = new Address(cityEntity, districtentity, contactName, addressLine1);

            var createAddressCommand = new CreateAddressCommand()
            {


            };

            // Act
            await addressAppService.Save(createAddressCommand);

            // Assert
            addressRepositoryMock.Verify(repo => repo.Add(It.IsAny<Address>()), Times.Once);
        }

        [Theory]
        [InlineData("Salvador", "district1", "igor moreira", "rua das flores")]
        [InlineData("Sao paulo", "district2", "Beltrão", "rua azul")]
        [InlineData("Fortaleza", "district3", "francisco coins", "rua twitch")]
        public async Task Save_ShouldHandleNullRepositoryResult(string city, string district, string contactName, string addressLine1)
        {
            //Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var addressAppService = new AddressAppService(
                addressRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var country = new Country("Brazil", "BRA", true, true, true, true, true);
            var state = new State("Ba", "Bahia", country, country.Id);
            var districtentity = new District("fourteen district", "two", "location");
            var cityEntity = new City(state.Id, "são paulo", state);


            var addressEntity = new Address(cityEntity, districtentity, contactName, addressLine1);

            var createAddressCommand = new CreateAddressCommand()
            {


            };

            addressRepositoryMock.Setup(repo => repo.Add(It.IsAny<Address>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => addressAppService.Save(createAddressCommand));

        }

        [Theory]
        [InlineData("Salvador", "district1", "igor moreira", "rua das flores")]
        [InlineData("Sao paulo", "district2", "Beltrão", "rua azul")]
        [InlineData("Fortaleza", "district3", "francisco coins", "rua twitch")]
        public async Task Save_ShouldHandleInvalidMappingResult(string city, string district, string contactName, string addressLine1)
        {

            //Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var country = new Country("Brazil", "BRA", true, true, true, true, true);
            var state = new State("Ba", "Bahia", country, country.Id);
            var districtentity = new District("fourteen district", "two", "location");
            var cityEntity = new City(state.Id, "são paulo", state);


            var addressEntity = new Address(cityEntity, districtentity, contactName, addressLine1);

            var createCompanyCommand = new CreateCompanyCommand()
            {


            };

            // Act       
            companyRepositoryMock.Setup(repo => repo.Add(It.IsAny<Company>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.Save(createCompanyCommand));
        }

    }

}
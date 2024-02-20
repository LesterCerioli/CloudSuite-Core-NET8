using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CountryAppServiceTests
    {
        [Theory]
        [InlineData("Brazil", "55", true, false, true, false, true)]
        [InlineData("Nigeria", "22", true, false, true, false, true)]
        [InlineData("India", "11", true, false, true, false, true)]
        public async Task GetByName_ShouldReturnsCompanyViewModel(string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)
        {
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );          

            var countryEntity = new Country(countryName, code3, isBillingEnabled, isShippingEnabled, isCityEnabled, isZipCodeEnabled, isDistrictEnabled);

            countryRepositoryMock.Setup(repo => repo.GetByName(countryName)).ReturnsAsync(countryEntity);

            var expectedViewModel = new CountryViewModel()
            {
                Id = countryEntity.Id,
                CountryName = countryName,
                Code3 = code3,
                IsBillingEnabled = isBillingEnabled,
                IsShippingEnabled = isShippingEnabled,
                IsCityEnabled = isCityEnabled,
                IsZipCodeEnabled = isZipCodeEnabled,
                IsDistrictEnabled = isDistrictEnabled,
                StateId = Guid.NewGuid()
            };

            mapperMock.Setup(mapper => mapper.Map<CountryViewModel>(countryEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByName(countryName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Brazil")]
        [InlineData("Nigeria")]
        [InlineData("India")]
        public async Task GetByName_ShouldHandleNullRepositoryResult(string countryName)
        {
            // Arrange
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            countryRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>()))
                .ReturnsAsync((Country)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByName(countryName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Alemanha")]
        [InlineData("China")]
        [InlineData("coreia")]
        public async Task GetByName_ShouldHandleInvalidMappingResult(string countryName)
        {
            // Arrange
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var countryAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            countryRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => countryAppService.GetByName(countryName));
        }

        [Theory]
        [InlineData("Brazil", "55", true, false, true, false, true)]
        [InlineData("pais de gales", "22", true, false, true, false, true)]
        [InlineData("colombia", "11", true, false, true, false, true)]
        public async Task Save_ShouldAddCompanyToRepository(string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)
        {
            // Arrange
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var countryAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createCountryCommand = new CreateCountryCommand()
            {
                CountryName = countryName,
                Code3 = code3,
                IsBillingEnabled = isBillingEnabled,
                IsShippingEnabled = isShippingEnabled,
                IsCityEnabled = isCityEnabled,
                IsZipCodeEnabled = isZipCodeEnabled,
                IsDistrictEnabled = isDistrictEnabled,
                StateId = Guid.NewGuid()
            };

            // Act
            await countryAppService.Save(createCountryCommand);

            // Assert
            countryRepositoryMock.Verify(repo => repo.Add(It.IsAny<Country>()), Times.Once);
        }

        [Theory]
        [InlineData("Equador", "55", true, false, true, false, true)]
        [InlineData("Nigeria", "33", true, false, true, false, true)]
        [InlineData("Croacia", "45", true, false, true, false, true)]
        public async Task Save_ShouldHandleNullRepositoryResult(string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)
        {
            //Arrange
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var countryAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createCountryCommand = new CreateCountryCommand()
            {
                CountryName = countryName,
                Code3 = code3,
                IsBillingEnabled = isBillingEnabled,
                IsShippingEnabled = isShippingEnabled,
                IsCityEnabled = isCityEnabled,
                IsZipCodeEnabled = isZipCodeEnabled,
                IsDistrictEnabled = isDistrictEnabled,
                StateId = Guid.NewGuid()
            };

            countryRepositoryMock.Setup(repo => repo.Add(It.IsAny<Country>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => countryAppService.Save(createCountryCommand));

        }

        [Theory]
        [InlineData("Espanha", "89", true, false, true, false, true)]
        [InlineData("Nigeria", "42", true, false, true, false, true)]
        [InlineData("India", "11", true, false, true, false, true)]
        public async Task Save_ShouldHandleInvalidMappingResult(string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)

        {

            //Arrange
            var countryRepositoryMock = new Mock<ICountryRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var countryAppService = new CountryAppService(
                countryRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createCountryCommand = new CreateCountryCommand()
            {
                CountryName = countryName,
                Code3 = code3,
                IsBillingEnabled = isBillingEnabled,
                IsShippingEnabled = isShippingEnabled,
                IsCityEnabled = isCityEnabled,
                IsZipCodeEnabled = isZipCodeEnabled,
                IsDistrictEnabled = isDistrictEnabled,
                StateId = Guid.NewGuid()
            };

            // Act       
            countryRepositoryMock.Setup(repo => repo.Add(It.IsAny<Country>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => countryAppService.Save(createCountryCommand));
        }

    }
}

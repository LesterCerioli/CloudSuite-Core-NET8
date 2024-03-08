using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services
{
    public class CompanyAppServiceTests
    {
        [Theory]
        [InlineData("91761346000168", "americanas", "lojas americanas")]
        [InlineData("91761346000168", "subamarino", "buscape")]
        [InlineData("91761346000168", "buscape", "submarino")]
        public async Task GetByCnpj_ShouldReturnsCompanyViewModel(string cnpj, string fantasyName, string registerName)
        {
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );
            var country = new Country(Guid.NewGuid(), "Brazil", "BRA", true, true, true, true, true);
            var state = new State(Guid.NewGuid(), "Ba", "Bahia", country, country.Id);
            var city = new City(Guid.NewGuid(), "são paulo", state);
            var district = new District(Guid.NewGuid(), "fourteen district", "two", "location");
            var address = new Address(Guid.NewGuid(), city, district, "albert whesker", "umbrella street");

            var companyEntity = new Company(Guid.NewGuid(), new Cnpj(cnpj), "company Fantasy", "Fantasy ltda", address);

            companyRepositoryMock.Setup(repo => repo.GetByCnpj(new Cnpj(cnpj))).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                FantasyName = fantasyName,
                RegisterName = registerName
            };

            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByCnpj(new Cnpj(cnpj));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("40447165000120")]
        [InlineData("70726348000146")]
        [InlineData("46721479000156")]
        public async Task GetByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByCnpj(new Cnpj(cnpj));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("88007304000121")]
        [InlineData("36450540000114")]
        [InlineData("20095090000159")]
        public async Task GetByCnpj_ShouldHandleInvalidMappingResult(string cnpj)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetByCnpj(new Cnpj(cnpj)));
        }

        [Theory]
        [InlineData("36450540000114", "riot", "riot games")]
        [InlineData("10229691000153", "naugthy dog", "naugthy dog inc")]
        [InlineData("20095090000159", "rockstart", "rockstart games")]
        public async Task GetByFantasyName_ShouldReturnsCompanyViewModel(string cnpj, string fantasyName, string registerName)
        {
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );
            var country = new Country(Guid.NewGuid(), "Brazil", "BRA", true, true, true, true, true);
            var state = new State(Guid.NewGuid(), "Ba", "Bahia", country, country.Id);
            var city = new City(Guid.NewGuid(), "são paulo", state);
            var district = new District(Guid.NewGuid(), "fourteen district", "two", "location");
            var address = new Address(Guid.NewGuid(), city, district, "albert whesker", "umbrella street");

            var companyEntity = new Company(Guid.NewGuid(), new Cnpj(cnpj), "company Fantasy", "Fantasy ltda", address);

            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(fantasyName)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                FantasyName = fantasyName,
                RegisterName = registerName
            };

            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByFantasyName(fantasyName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }


        [Theory]
        [InlineData("riot")]
        [InlineData("naugthy dog")]
        [InlineData("rockstart")]
        public async Task GetByFantasyName_ShouldHandleNullRepositoryResult(string fantasyName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(It.IsAny<string>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByFantasyName(fantasyName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("americanas")]
        [InlineData("subamarino")]
        [InlineData("buscape")]
        public async Task GetByFantasyName_ShouldHandleInvalidMappingResult(string fantasyName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByFantasyName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetByFantasyName(fantasyName));
        }

        [Theory]
        [InlineData("71900468000180", "riot", "riot games")]
        [InlineData("31239661000106", "naugthy dog", "naugthy dog inc")]
        [InlineData("08892859000164", "redflag", "redflag ltda")]
        public async Task GetByRegisterName_ShouldReturnsCompanyViewModel(string cnpj, string fantasyName, string registerName)
        {
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );
            var country = new Country(Guid.NewGuid(), "Brazil", "BRA", true, true, true, true, true);
            var state = new State(Guid.NewGuid(), "Ba", "Bahia", country, country.Id);
            var city = new City(Guid.NewGuid(), "são paulo", state);
            var district = new District(Guid.NewGuid(), "fourteen district", "two", "location");
            var address = new Address(Guid.NewGuid(), city, district, "albert whesker", "umbrella street");

            var companyEntity = new Company(Guid.NewGuid(), new Cnpj(cnpj), "company Fantasy", "Fantasy ltda", address);

            companyRepositoryMock.Setup(repo => repo.GetByRegisterName(registerName)).ReturnsAsync(companyEntity);

            var expectedViewModel = new CompanyViewModel()
            {
                Id = companyEntity.Id,
                FantasyName = fantasyName,
                RegisterName = registerName
            };

            mapperMock.Setup(mapper => mapper.Map<CompanyViewModel>(companyEntity)).Returns(expectedViewModel);

            // Act
            var result = await companyAppService.GetByRegisterName(registerName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("riot")]
        [InlineData("naugthy dog")]
        [InlineData("rockstart")]
        public async Task GetByRegisterName_ShouldHandleNullRepositoryResult(string registerName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByRegisterName(It.IsAny<string>()))
                .ReturnsAsync((Company)null); // Simulate null result from the repository

            // Act
            var result = await companyAppService.GetByRegisterName(registerName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("americanas")]
        [InlineData("subamarino")]
        [InlineData("buscape")]
        public async Task GetByRegisterName_ShouldHandleInvalidMappingResult(string registerName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            companyRepositoryMock.Setup(repo => repo.GetByRegisterName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => companyAppService.GetByRegisterName(registerName));
        }

        [Theory]
        [InlineData("71900468000180", "riot", "riot games")]
        [InlineData("31239661000106", "naugthy dog", "naugthy dog inc")]
        [InlineData("08892859000164", "redflag", "redflag ltda")]
        public async Task Save_ShouldAddCompanyToRepository(string cnpj, string fantasyName, string registerName)
        {
            // Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createCityCommand = new CreateCompanyCommand()
            {


            };

            // Act
            await companyAppService.Save(createCityCommand);

            // Assert
            companyRepositoryMock.Verify(repo => repo.Add(It.IsAny<Company>()), Times.Once);
        }

        [Theory]
        [InlineData("71900468000180", "riot", "riot games")]
        [InlineData("31239661000106", "naugthy dog", "naugthy dog inc")]
        [InlineData("08892859000164", "redflag", "redflag ltda")]
        public async Task Save_ShouldHandleNullRepositoryResult(string cnpj, string fantasyName, string registerName)
        {
            //Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createCompanyCommand = new CreateCompanyCommand()
            {


            };

            companyRepositoryMock.Setup(repo => repo.Add(It.IsAny<Company>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => companyAppService.Save(createCompanyCommand));

        }

        [Theory]
        [InlineData("71900468000180", "riot", "riot games")]
        [InlineData("31239661000106", "naugthy dog", "naugthy dog inc")]
        [InlineData("08892859000164", "redflag", "redflag ltda")]
        public async Task Save_ShouldHandleInvalidMappingResult(string cnpj, string fantasyName, string registerName)
        {

            //Arrange
            var companyRepositoryMock = new Mock<ICompanyRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var companyAppService = new CompanyAppService(
                companyRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

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

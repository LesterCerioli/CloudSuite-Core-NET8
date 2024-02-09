using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User;
using CloudSuite.Modules.Application.Handlers.Vendor;
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
    public class VendorAppServiceTests
    {
        [Theory]
        [InlineData("igor moreira", "up", "descricao de venda de carro", "48417537000188", true, false)]
        [InlineData("elton santos", "down", "descricao de venda moto", "25112871000128", true, false)]
        [InlineData("mateus costa", "left", "descricao de venda celular", "65463845000169", true, false)]
        public async Task GetByCnpj_ShouldReturnsCompanyViewModel(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {

            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);
            var userEntity = new User("user name", email, new Cpf("06536709586"), new Telephone("71988890834"), true, "837429834798328347923923847");

            var vendorEntity = new Vendor(userEntity.Id, name, slug, description, new Cnpj(cnpj), email, DateTimeOffset.Now, DateTimeOffset.Now, isActive, isDeleted);

            vendorRepositoryMock.Setup(repo => repo.GetByCnpj(new Cnpj(cnpj))).ReturnsAsync(vendorEntity);


            var expectedViewModel = new VendorViewModel()
            {
                Id = vendorEntity.Id,
                Name = name,
                Slug = slug,
                Description = description,
                Cnpj = cnpj,
                Email = email.Body,
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now
            };

            mapperMock.Setup(mapper => mapper.Map<VendorViewModel>(vendorEntity)).Returns(expectedViewModel);

            // Act
            var result = await vendorAppService.GetByCnpj(new Cnpj(cnpj));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("36775033000150")]
        [InlineData("51536379000190")]
        [InlineData("24868087000181")]
        public async Task GetByCnpj_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>())).ReturnsAsync((Vendor)null); // Simulate null result from the repository

            // Act
            var result = await vendorAppService.GetByCnpj(new Cnpj(cnpj));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("92299046000171")]
        [InlineData("84498645000196")]
        [InlineData("13754238000154")]
        public async Task GetByCnpj_ShouldHandleInvalidMappingResult(string cnpj)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByCnpj(It.IsAny<Cnpj>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => vendorAppService.GetByCnpj(new Cnpj(cnpj)));
        }

        [Theory]
        [InlineData("flora matos", "down", "descricao de venda de um apartamento", "92155393000120", true, false)]
        [InlineData("vanessa lopes", "slug1", "descricao de venda de uma chacara", "73549653000106", true, false)]
        [InlineData("davi barbosa", "left", "descricao de venda", "54814207000129", true, false)]
        public async Task GetByCreatedOn_ShouldReturnsCompanyViewModel(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {

            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);
            var userEntity = new User("user name", email, new Cpf("06536709586"), new Telephone("71988890834"), true, "837429834798328347923923847");

            var vendorEntity = new Vendor(userEntity.Id, name, slug, description, new Cnpj(cnpj), email, DateTimeOffset.Now, DateTimeOffset.Now, isActive, isDeleted);

            vendorRepositoryMock.Setup(repo => repo.GetByCreatedOn(DateTimeOffset.Now)).ReturnsAsync(vendorEntity);


            var expectedViewModel = new VendorViewModel()
            {
                Id = vendorEntity.Id,
                Name = name,
                Slug = slug,
                Description = description,
                Cnpj = cnpj,
                Email = email.Body,
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now
            };

            mapperMock.Setup(mapper => mapper.Map<VendorViewModel>(vendorEntity)).Returns(expectedViewModel);

            // Act
            var result = await vendorAppService.GetByCreatedOn(DateTimeOffset.Now);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("02-04-2023")]
        [InlineData("19-08-2023")]
        [InlineData("09-11-2023")]
        public async Task GetByCreatedOn_ShouldHandleNullRepositoryResult(string cnpj)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByCreatedOn(It.IsAny<DateTimeOffset>())).ReturnsAsync((Vendor)null); // Simulate null result from the repository

            // Act
            var result = await vendorAppService.GetByCreatedOn(DateTimeOffset.Now);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("25-12-2023")]
        [InlineData("14-03-2023")]
        [InlineData("01-07-2023")]
        public async Task GetByCreatedOn_ShouldHandleInvalidMappingResult(string cnpj)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByCreatedOn(It.IsAny<DateTimeOffset>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => vendorAppService.GetByCreatedOn(DateTimeOffset.Now));
        }


        [Theory]
        [InlineData("igor moreira", "up", "descricao de venda de carro", "48417537000188", true, false)]
        [InlineData("elton santos", "down", "descricao de venda moto", "25112871000128", true, false)]
        [InlineData("mateus costa", "left", "descricao de venda celular", "65463845000169", true, false)]
        public async Task GetByName_ShouldReturnsCompanyViewModel(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {

            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);
            var userEntity = new User("user name", email, new Cpf("06536709586"), new Telephone("71988890834"), true, "837429834798328347923923847");

            var vendorEntity = new Vendor(userEntity.Id, name, slug, description, new Cnpj(cnpj), email, DateTimeOffset.Now, DateTimeOffset.Now, isActive, isDeleted);

            vendorRepositoryMock.Setup(repo => repo.GetByName(name)).ReturnsAsync(vendorEntity);


            var expectedViewModel = new VendorViewModel()
            {
                Id = vendorEntity.Id,
                Name = name,
                Slug = slug,
                Description = description,
                Cnpj = cnpj,
                Email = email.Body,
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now
            };

            mapperMock.Setup(mapper => mapper.Map<VendorViewModel>(vendorEntity)).Returns(expectedViewModel);

            // Act
            var result = await vendorAppService.GetByName(name);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("igor moreira")]
        [InlineData("debora moreira")]
        [InlineData("lucas vinicus")]
        public async Task GetByName_ShouldHandleNullRepositoryResult(string name)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>())).ReturnsAsync((Vendor)null); // Simulate null result from the repository

            // Act
            var result = await vendorAppService.GetByCnpj(name);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("gabriela santos")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        public async Task GetByName_ShouldHandleInvalidMappingResult(string name)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            vendorRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => vendorAppService.GetByName(name));
        }

        [Theory]
        [InlineData("flora matos", "down", "descricao de venda de um apartamento", "92155393000120", true, false)]
        [InlineData("vanessa lopes", "slug1", "descricao de venda de uma chacara", "73549653000106", true, false)]
        [InlineData("davi barbosa", "left", "descricao de venda", "54814207000129", true, false)]
        public async Task Save_ShouldAddCompanyToRepository(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {
            // Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var createVendorCommand = new CreateVendorCommand()
            {


            };

            // Act
            await vendorAppService.Save(createVendorCommand);

            // Assert
            vendorRepositoryMock.Verify(repo => repo.Add(It.IsAny<Vendor>()), Times.Once);
        }

        [Theory]
        [InlineData("igor moreira", "up", "descricao de venda de carro", "48417537000188", true, false)]
        [InlineData("elton santos", "down", "descricao de venda moto", "25112871000128", true, false)]
        [InlineData("mateus costa", "left", "descricao de venda celular", "65463845000169", true, false)]
        public async Task Save_ShouldHandleNullRepositoryResult(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {
            //Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var createVendorCommand = new CreateVendorCommand()
            {


            };

            vendorRepositoryMock.Setup(repo => repo.Add(It.IsAny<Vendor>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => vendorAppService.Save(createVendorCommand));

        }

        [Theory]
        [InlineData("igor moreira", "up", "descricao de venda de carro", "48417537000188", true, false)]
        [InlineData("elton santos", "down", "descricao de venda moto", "25112871000128", true, false)]
        [InlineData("mateus costa", "left", "descricao de venda celular", "65463845000169", true, false)]
        public async Task Save_ShouldHandleInvalidMappingResult(string name, string slug, string description, string cnpj, bool isActive, bool isDeleted)
        {

            //Arrange
            var vendorRepositoryMock = new Mock<IVendorRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var vendorAppService = new VendorAppService(
                vendorRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var createVendorCommand = new CreateVendorCommand()
            {


            };

            // Act       
            vendorRepositoryMock.Setup(repo => repo.Add(It.IsAny<Vendor>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => vendorAppService.Save(createVendorCommand));
        }

    }
}

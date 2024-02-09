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
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
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
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
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
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
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
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
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
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
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
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
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
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
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
        [InlineData("wiuye")]
        [InlineData("wiuye")]
        [InlineData("wiuye")]
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
        [InlineData("wiuye")]
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
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
        [InlineData("igor", "up", "descricao de venda", "53343512000117", true, false)]
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
        [InlineData("8575", 8722, "998w", MediaType.Image)]
        [InlineData("8575", 8722, "998w", MediaType.File)]
        [InlineData("8575", 8722, "998w", MediaType.Video)]
        public async Task Save_ShouldHandleNullRepositoryResult(string caption, int fileSize, string fileName, MediaType mediaType)
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
        [InlineData("8575", 8722, "998w", MediaType.Image)]
        [InlineData("8575", 8722, "998w", MediaType.File)]
        [InlineData("8575", 8722, "998w", MediaType.Video)]
        public async Task Save_ShouldHandleInvalidMappingResult(string caption, int fileSize, string fileName, MediaType mediaType)
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

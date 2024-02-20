using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.State;
using CloudSuite.Modules.Application.Handlers.User;
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
    public class UserAppServiceTests
    {
        [Theory]
        [InlineData("genivaldo lopes", "33803834066", "31987656532", true, "10-10-2023", "02-06-2022", "7654696756")]
        [InlineData("clara santos", "33803834066", "77988890834", true, "10-10-2023", "11-05-2021", "94387594857")]
        [InlineData("brenda bittencourt", "12540079032", "21987656785", true, "10-10-2023", "11-12-2023", "876574654")]
        public async Task GetByCpf_ShouldReturnsCompanyViewModel(string fullname, string cpf, string telephone, bool isDeleted, DateTimeOffset createdOn, DateTimeOffset latestUpdatedOn, string refreshTokenHash)
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var userEntity = new User("user name", email, new Cpf("06536709586"), new Telephone("71988890834"), isDeleted, createdOn, latestUpdatedOn, refreshTokenHash);

            userRepositoryMock.Setup(repo => repo.GetByCpf(new Cpf(cpf))).ReturnsAsync(userEntity);


            var expectedViewModel = new UserViewModel()
            {
                Id = userEntity.Id,
                FullName = fullname,
                Email = email.Body,
                Cpf = cpf,
                Telephone = telephone,
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now
            };

            mapperMock.Setup(mapper => mapper.Map<UserViewModel>(userEntity)).Returns(expectedViewModel);

            // Act
            var result = await userAppService.GetByCpf(new Cpf(cpf));

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("31506415008")]
        [InlineData("86483251025")]
        [InlineData("67473576046")]
        public async Task GetByCpf_ShouldHandleNullRepositoryResult(string cpf)
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            userRepositoryMock.Setup(repo => repo.GetByCpf(It.IsAny<Cpf>())).ReturnsAsync((User)null); // Simulate null result from the repository

            // Act
            var result = await userAppService.GetByCpf(new Cpf(cpf));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("12658694059")]
        [InlineData("39192181082")]
        [InlineData("48882288099")]
        public async Task GetByCpf_ShouldHandleInvalidMappingResult(string cpf)
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            userRepositoryMock.Setup(repo => repo.GetByCpf(It.IsAny<Cpf>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userAppService.GetByCpf(new Cpf(cpf)));
        }

        [Theory]
        [InlineData("lucas santos", "06536709586", "71987657684", true, "10-10-2023", "11-12-2023", "76578576587")]
        [InlineData("adalberto santos", "06536709586", "81987687690", true, "10-12-2023", "11-12-2022", "3967358098897")]
        [InlineData("thiago santos", "06536709586", "77988890834", false, "10-10-2023", "11-12-2022", "4323678980975")]
        public async Task GetByEmail_ShouldReturnsCompanyViewModel(string fullname, string cpf, string telephone, bool isDeleted, DateTimeOffset createdOn, DateTimeOffset latestUpdatedOn, string refreshTokenHash)
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var userEntity = new User(fullname, email, new Cpf(cpf), new Telephone(telephone), isDeleted, createdOn, latestUpdatedOn, refreshTokenHash);

            userRepositoryMock.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(userEntity);


            var expectedViewModel = new UserViewModel()
            {
                Id = userEntity.Id,
                FullName = fullname,
                Email = email.Body,
                Cpf = cpf,
                Telephone = telephone,
                CreatedOn = createdOn,
                LatestUpdatedOn = latestUpdatedOn

            };

            mapperMock.Setup(mapper => mapper.Map<UserViewModel>(userEntity)).Returns(expectedViewModel);

            // Act
            var result = await userAppService.GetByEmail(email);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("igorsantos2@icloud.com")]
        [InlineData("moreiraSantos2@bol.com")]
        [InlineData("santos23@gmail.com")]
        public async Task GetByEmail_ShouldHandleNullRepositoryResult(string email1)
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var email = new Email("warning", "text message", email1, "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            userRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>())).ReturnsAsync((User)null); // Simulate null result from the repository

            // Act
            var result = await userAppService.GetByEmail(email);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("orangotango22@icloud.com")]
        [InlineData("moreiraSantos2@outlook.com")]
        [InlineData("santos23@gmail.com")]
        public async Task GetByEmail_ShouldHandleInvalidMappingResult(string email)
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );
            var emailentity = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);
            userRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<Email>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userAppService.GetByEmail(emailentity));
        }
        /*
        [Theory]
        [InlineData("genivaldo lopes", "33803834066", "31987656532", true, "10-10-2023", "02-06-2022", "7654696756", "culture12", "extensionData5")]
        [InlineData("clara santos", "33803834066", "77988890834", true, "10-10-2023", "11-05-2021", "94387594857", "culture13", "extensionData6")]
        [InlineData("brenda bittencourt", "12540079032", "21987656785", true, "10-10-2023", "11-12-2023", "876574654", "culture14", "extensionData7")]
        public async Task Save_ShouldAddCompanyToRepository(string fullname, string cpf, string telephone, bool isDeleted, DateTimeOffset createdOn, DateTimeOffset latestUpdatedOn, string refreshTokenHash, string culture, string? extensionData)

        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var createUserCommand = new CreateUserCommand()
            {


            };

            // Act
            await userAppService.Save(createUserCommand);

            // Assert
            userRepositoryMock.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
        }

        [Theory]
        [InlineData("lucas santos", "06536709586", "71987657684", true, "10-10-2023", "11-12-2023", "76578576587", "culture12", "extensionData7")]
        [InlineData("thiago santos", "06536709586", "77988890834", false, "15-01-2023", "11-12-2020", "4323678980975", "culture13", "extensionData6")]
        [InlineData("adalberto santos", "06536709586", "81987687690", true, "10-12-2023", "11-12-2022", "3967358098897", "culture14", "extensionData5")]
        public async Task Save_ShouldHandleNullRepositoryResult(string fullname, string cpf, string telephone, bool isDeleted, DateTimeOffset createdOn, DateTimeOffset latestUpdatedOn, string refreshTokenHash, string culture, string? extensionData)

        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var email = new Email("warning", "text message", "apple", "juninho", DateTimeOffset.Now, true, 3, CodeErrorEmail.NetworkError);

            var createUserCommand = new CreateUserCommand()
            {


            };

            userRepositoryMock.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => userAppService.Save(createUserCommand));

        }

        [Theory]
        [InlineData("lucas santos", "06536709586", "71987657684", true, "10-10-2023", "11-12-2023", "76578576587", "culture12", "extensionData7")]
        [InlineData("thiago santos", "06536709586", "77988890834", false, "15-01-2023", "11-12-2020", "4323678980975", "culture13", "extensionData6")]
        [InlineData("adalberto santos", "06536709586", "81987687690", true, "10-12-2023", "11-12-2022", "3967358098897", "culture14", "extensionData5")]
        public async Task Save_ShouldHandleInvalidMappingResult(string fullname, string cpf, string telephone, bool isDeleted, DateTimeOffset createdOn, DateTimeOffset latestUpdatedOn, string refreshTokenHash, string culture, string? extensionData)

        {

            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var userAppService = new UserAppService(
                userRepositoryMock.Object,
                mapperMock.Object,
                mediatorHandlerMock.Object
            );

            var createUserCommand = new CreateUserCommand()
            {


            };

            // Act       
            userRepositoryMock.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userAppService.Save(createUserCommand));
        }

        */
    }
}

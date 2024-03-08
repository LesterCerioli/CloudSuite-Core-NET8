using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.District;
using CloudSuite.Modules.Application.Handlers.Email;
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
    public class EmailAppServiceTests
    {
        [Theory]
        [InlineData("emailteste1", "texto de teste1", "senderdeteste@email.com", "hotmail", "10-12-2023", true, 1, CodeErrorEmail.UnknownError, "0")]
        [InlineData("emailteste1", "texto de teste1", "senderdeteste@email.com", "hotmail", "10-12-2023", false, 2, CodeErrorEmail.SmtpError, "1")]
        [InlineData("emailteste1", "texto de teste1", "senderdeteste@email.com", "hotmail", "10-12-2023", true, 3, CodeErrorEmail.InvalidRecipient, "2")]
        public async Task GetByCodeErrorEmail_ShouldReturnsCompanyViewModel(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail, string codeErrorEmail2)
        {
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var emailEntity = new Email(subject, body, sender, recipient, sentDate, isRead);
            emailRepositoryMock.Setup(repo => repo.GetByCodeErrorEmail(codeErrorEmail)).ReturnsAsync(emailEntity);


            var expectedViewModel = new EmailViewModel()
            {
                Id = emailEntity.Id,
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate
            };

            mapperMock.Setup(mapper => mapper.Map<EmailViewModel>(emailEntity)).Returns(expectedViewModel);

            // Act
            var result = await emailAppService.GetByCodeErrorEmail(codeErrorEmail);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData(CodeErrorEmail.NetworkError)]
        [InlineData(CodeErrorEmail.AttachmentError)]
        [InlineData(CodeErrorEmail.TimeoutError)]
        public async Task GetByCodeErrorEmail_ShouldHandleNullRepositoryResult(CodeErrorEmail codeErrorEmail)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetByCodeErrorEmail(It.IsAny<CodeErrorEmail>())).ReturnsAsync((Email)null); // Simulate null result from the repository

            // Act
            var result = await emailAppService.GetByCodeErrorEmail(codeErrorEmail);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(CodeErrorEmail.AuthenticationError)]
        [InlineData(CodeErrorEmail.UnknownError)]
        [InlineData(CodeErrorEmail.SmtpError)]
        public async Task GetByCodeErrorEmail_ShouldHandleInvalidMappingResult(CodeErrorEmail codeErrorEmail)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetByCodeErrorEmail(It.IsAny<CodeErrorEmail>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => emailAppService.GetByCodeErrorEmail(codeErrorEmail));
        }


        [Theory]
        [InlineData("emailteste3", "texto de teste4", "senderdeteste4@email.com", "bol", "10-12-2023", false, 4, CodeErrorEmail.UnknownError, "032")]
        [InlineData("emailteste4", "texto de teste5", "senderdeteste5@email.com", "gmail", "10-12-2023", true, 5, CodeErrorEmail.SmtpError, "132")]
        [InlineData("emailteste5", "texto de teste6", "senderdeteste6@email.com", "icloud", "10-12-2023", false, 6, CodeErrorEmail.InvalidRecipient, "2123")]
        public async Task GetByRecipient_ShouldReturnsCompanyViewModel(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail, string codeErrorEmail2)
        {
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var emailEntity = new Email(subject, body, sender, recipient, sentDate, isRead);

            emailRepositoryMock.Setup(repo => repo.GetByRecipient(recipient)).ReturnsAsync(emailEntity);


            var expectedViewModel = new EmailViewModel()
            {
                Id = emailEntity.Id,
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate,
            };

            mapperMock.Setup(mapper => mapper.Map<EmailViewModel>(emailEntity)).Returns(expectedViewModel);

            // Act
            var result = await emailAppService.GetByRecipient(recipient);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("recipient1")]
        [InlineData("recipient2")]
        [InlineData("recipient3")]
        public async Task GetByRecipient_ShouldHandleNullRepositoryResult(string recipient)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetByRecipient(It.IsAny<string>())).ReturnsAsync((Email)null); // Simulate null result from the repository

            // Act
            var result = await emailAppService.GetByRecipient(recipient);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("recipient4")]
        [InlineData("recipient5")]
        [InlineData("recipient6")]
        public async Task GetByRecipient_ShouldHandleInvalidMappingResult(string recipient)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetByRecipient(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => emailAppService.GetByRecipient(recipient));
        }


        [Theory]
        [InlineData("emailteste9345@", "texto de teste43123554", "senderdeteste564@email.com", "hotmail", "10-12-2023", true, 8, CodeErrorEmail.UnknownError, "05")]
        [InlineData("emailteste6438", "texto de teste3134", "senderdeteste2347@email.com", "bol", "10-12-2023", true, 7, CodeErrorEmail.SmtpError, "14")]
        [InlineData("emailteste2347", "texto de teste15443", "senderdeteste987@email.com", "gmail", "10-12-2023", true, 6, CodeErrorEmail.InvalidRecipient, "26")]
        public async Task GetBySender_ShouldReturnsCompanyViewModel(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail, string codeErrorEmail2)
        {
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var emailEntity = new Email(subject, body, sender, recipient, sentDate, isRead);

            emailRepositoryMock.Setup(repo => repo.GetBySender(sender)).ReturnsAsync(emailEntity);


            var expectedViewModel = new EmailViewModel()
            {
                Id = emailEntity.Id,
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate,
            };

            mapperMock.Setup(mapper => mapper.Map<EmailViewModel>(emailEntity)).Returns(expectedViewModel);

            // Act
            var result = await emailAppService.GetBySender(sender);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("sendr1@hotmail.com")]
        [InlineData("sendr2@gmail.com")]
        [InlineData("sendr3@outlook.com")]
        public async Task GetBySender_ShouldHandleNullRepositoryResult(string sender)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetBySender(It.IsAny<string>())).ReturnsAsync((Email)null); // Simulate null result from the repository

            // Act
            var result = await emailAppService.GetBySender(sender);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("sendr1@bol.com")]
        [InlineData("sendr2@yahoo.com")]
        [InlineData("sendr3@email.com")]
        public async Task GetBySender_ShouldHandleInvalidMappingResult(string sender)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            emailRepositoryMock.Setup(repo => repo.GetBySender(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => emailAppService.GetByRecipient(sender));
        }

        [Theory]
        [InlineData("emailteste3", "texto de teste4", "senderdeteste4@email.com", "bol", "10-12-2023", false, 4, CodeErrorEmail.UnknownError)]
        [InlineData("emailteste4", "texto de teste5", "senderdeteste5@email.com", "gmail", "10-12-2023", true, 5, CodeErrorEmail.SmtpError)]
        [InlineData("emailteste5", "texto de teste6", "senderdeteste6@email.com", "icloud", "10-12-2023", false, 6, CodeErrorEmail.InvalidRecipient)]
        public async Task Save_ShouldAddCompanyToRepository(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail)
        {
            // Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createEmailCommand = new CreateEmailCommand()
            {
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate,
                IsRead = isRead,
                SendAttempts = sendAttempts,
                CodeErrorEmail = codeErrorEmail
            };

            // Act
            await emailAppService.Send(createEmailCommand);

            // Assert
            emailRepositoryMock.Verify(repo => repo.Add(It.IsAny<Email>()), Times.Once);
        }

        [Theory]
        [InlineData("emailteste9345", "texto de teste43123554", "senderdeteste564@email.com", "hotmail", "10-12-2023", true, 8, CodeErrorEmail.UnknownError)]
        [InlineData("emailteste6438", "texto de teste3134", "senderdeteste2347@email.com", "bol", "10-12-2023", true, 7, CodeErrorEmail.SmtpError)]
        [InlineData("emailteste2347", "texto de teste15443", "senderdeteste987@email.com", "gmail", "10-12-2023", true, 6, CodeErrorEmail.InvalidRecipient)]
        public async Task Save_ShouldHandleNullRepositoryResult(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail)
        {
            //Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createEmailCommand = new CreateEmailCommand()
            {
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate,
                IsRead = isRead,
                SendAttempts = sendAttempts,
                CodeErrorEmail = codeErrorEmail

            };

            emailRepositoryMock.Setup(repo => repo.Add(It.IsAny<Email>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => emailAppService.Send(createEmailCommand));

        }

        [Theory]
        [InlineData("emailteste9345", "texto de teste43123554", "senderdeteste564@email.com", "hotmail", "10-12-2023", true, 8, CodeErrorEmail.UnknownError)]
        [InlineData("emailteste6438", "texto de teste3134", "senderdeteste2347@email.com", "bol", "10-12-2023", true, 7, CodeErrorEmail.SmtpError)]
        [InlineData("emailteste2347", "texto de teste15443", "senderdeteste987@email.com", "gmail", "10-12-2023", true, 6, CodeErrorEmail.InvalidRecipient)]
        public async Task Save_ShouldHandleInvalidMappingResult(string subject, string body, string sender, string recipient, DateTimeOffset sentDate, bool isRead, int sendAttempts, CodeErrorEmail codeErrorEmail)
        {

            //Arrange
            var emailRepositoryMock = new Mock<IEmailRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var emailAppService = new EmailAppService(
                emailRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createEmailCommand = new CreateEmailCommand()
            {
                Subject = subject,
                Body = body,
                Sender = sender,
                Recipient = recipient,
                SentDate = sentDate,
                IsRead = isRead,
                SendAttempts = sendAttempts,
                CodeErrorEmail = codeErrorEmail
            };

            // Act       
            emailRepositoryMock.Setup(repo => repo.Add(It.IsAny<Email>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => emailAppService.Send(createEmailCommand));
        }

    }
}

using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Handlers.Email;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.ViewModels;
using MediatR;
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
    public class MediaAppServiceTests
    {
        [Theory]
        [InlineData("caption1", 233, "filename", MediaType.Image)]
        [InlineData("teste de caption", 8722, "arquivo", MediaType.File)]
        [InlineData("mutiplos captions", 450, "teste", MediaType.Video)]
        public async Task GetByFileName_ShouldReturnsCompanyViewModel(string caption, int fileSize, string fileName, MediaType mediaType)
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var mediaEntity = new Media(caption, fileSize, fileName, mediaType);

            mediaRepositoryMock.Setup(repo => repo.GetByFileName(fileName)).ReturnsAsync(mediaEntity);


            var expectedViewModel = new MediaViewModel()
            {
                Id = mediaEntity.Id,
                Caption = caption,
                FileSize = fileSize,
                FileName = fileName
            };

            mapperMock.Setup(mapper => mapper.Map<MediaViewModel>(mediaEntity)).Returns(expectedViewModel);

            // Act
            var result = await mediaAppService.GetByFileName(fileName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("file")]
        [InlineData("arquivo")]
        [InlineData("index")]
        public async Task GetByFileName_ShouldHandleNullRepositoryResult(string filename)
        {
            // Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            mediaRepositoryMock.Setup(repo => repo.GetByFileName(It.IsAny<string>())).ReturnsAsync((Media)null); // Simulate null result from the repository

            // Act
            var result = await mediaAppService.GetByFileName(filename);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("mouse")]
        [InlineData("keyboard")]
        [InlineData("headset")]
        public async Task GetByFileName_ShouldHandleInvalidMappingResult(string filename)
        {
            // Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            mediaRepositoryMock.Setup(repo => repo.GetByFileName(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => mediaAppService.GetByFileName(filename));
        }

        [Theory]
        [InlineData("caption text1", 089, "arquivos e nomes", MediaType.Image)]
        [InlineData("legendas incluidas", 765, "word", MediaType.File)]
        [InlineData("diversos tipos", 321, "excel", MediaType.Video)]
        public async Task GetByFileSize_ShouldReturnsCompanyViewModel(string caption, int fileSize, string fileName, MediaType mediaType)
        {
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var mediaEntity = new Media(caption, fileSize, fileName, mediaType);

            mediaRepositoryMock.Setup(repo => repo.GetByFileName(fileName)).ReturnsAsync(mediaEntity);


            var expectedViewModel = new MediaViewModel()
            {
                Id = mediaEntity.Id,
                Caption = caption,
                FileSize = fileSize,
                FileName = fileName
            };

            mapperMock.Setup(mapper => mapper.Map<MediaViewModel>(mediaEntity)).Returns(expectedViewModel);

            // Act
            var result = await mediaAppService.GetByFileName(fileName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(11)]
        [InlineData(33)]
        public async Task GetByFileSize_ShouldHandleNullRepositoryResult(int filesize)
        {
            // Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            mediaRepositoryMock.Setup(repo => repo.GetByFileSize(It.IsAny<int>())).ReturnsAsync((Media)null); // Simulate null result from the repository

            // Act
            var result = await mediaAppService.GetByFileSize(filesize);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(123)]
        [InlineData(321)]
        [InlineData(234)]
        public async Task GetByFileSize_ShouldHandleInvalidMappingResult(int filesize)
        {
            // Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            mediaRepositoryMock.Setup(repo => repo.GetByFileSize(It.IsAny<int>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => mediaAppService.GetByFileSize(filesize));
        }

        [Theory]
        [InlineData("caption1", 233, "filename", MediaType.Image)]
        [InlineData("teste de caption", 8722, "arquivo", MediaType.File)]
        [InlineData("mutiplos captions", 450, "teste", MediaType.Video)]
        public async Task Save_ShouldAddCompanyToRepository(string caption, int fileSize, string fileName, MediaType mediaType)
        {
            // Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createMediaCommand = new CreateMediaCommand()
            {


            };

            // Act
            await mediaAppService.Save(createMediaCommand);

            // Assert
            mediaRepositoryMock.Verify(repo => repo.Add(It.IsAny<Media>()), Times.Once);
        }

        [Theory]
        [InlineData("caption text1", 089, "arquivos e nomes", MediaType.Image)]
        [InlineData("legendas incluidas", 765, "word", MediaType.File)]
        [InlineData("diversos tipos", 321, "excel", MediaType.Video)]
        public async Task Save_ShouldHandleNullRepositoryResult(string caption, int fileSize, string fileName, MediaType mediaType)
        {
            //Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createMediaCommand = new CreateMediaCommand()
            {


            };

            mediaRepositoryMock.Setup(repo => repo.Add(It.IsAny<Media>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => mediaAppService.Save(createMediaCommand));

        }

        [Theory]
        [InlineData("caption text1", 089, "arquivos e nomes", MediaType.Image)]
        [InlineData("legendas incluidas", 765, "word", MediaType.File)]
        [InlineData("diversos tipos", 321, "excel", MediaType.Video)]
        public async Task Save_ShouldHandleInvalidMappingResult(string caption, int fileSize, string fileName, MediaType mediaType)
        {

            //Arrange
            var mediaRepositoryMock = new Mock<IMediaRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var mediaAppService = new MediaAppService(
                mediaRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
            );

            var createMediaCommand = new CreateMediaCommand()
            {


            };

            // Act       
            mediaRepositoryMock.Setup(repo => repo.Add(It.IsAny<Media>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => mediaAppService.Save(createMediaCommand));
        }

    }
}

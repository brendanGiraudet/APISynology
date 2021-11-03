using APISynology.Controllers;
using APISynology.Services;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace APISynology.Tests
{
    public class SynologyControllerTests
    {
        SynologyController CreateSynologyController() => new SynologyController(DefaultSynologyService);
        SynologyController CreateSynologyController(ISynologyService synologyService) => new SynologyController(synologyService);
        ISynologyService DefaultSynologyService
        {
            get
            {
                var mock = new Mock<ISynologyService>();

                mock.Setup(s => s.GetSIdAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(FakerUtils.SuccessSynologyDataLoginResponseFaker.Generate()))
                    .Verifiable();
                
                mock.Setup(s => s.GetFilesAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(FakerUtils.SuccessSynologyDataFileListResponseFaker.Generate()))
                    .Verifiable();
                
                mock.Setup(s => s.DeleteFileAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .Returns(Task.FromResult(FakerUtils.SuccessSynologyResponseFaker.Generate()))
                    .Verifiable();

                return mock.Object;
            }
        }

        #region GetSidAsync
        [Fact]
        public async Task ShouldHaveInternalServerErrorStatusCodeWhenGetSidWithNotSuccess()
        {
            // Arrange 
            var faker = new Faker();
            var fakeUser = faker.Random.String2(2);
            var fakePassword = faker.Random.String2(2);
            var customSynologyServiceMock = new Mock<ISynologyService>();
            customSynologyServiceMock.Setup(s => s.GetSIdAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(FakerUtils.ErrorSynologyDataLoginResponseFaker.Generate()))
                .Verifiable();
            var synologyController = CreateSynologyController(customSynologyServiceMock.Object);
            var expectedStatusCode = StatusCodes.Status500InternalServerError;

            // Act
            var getSidResponse = await synologyController.GetSidAsync(fakeUser, fakePassword);

            // Assert
            Assert.IsType<ObjectResult>(getSidResponse);
            var getsidResult = getSidResponse as ObjectResult;
            Assert.Equal(expectedStatusCode, getsidResult.StatusCode);
        }

        [Fact]
        public async Task ShouldHaveOkStatusCodeWhenGetSid()
        {
            // Arrange 
            var faker = new Faker();
            var fakeUser = faker.Random.String2(2);
            var fakePassword = faker.Random.String2(2);
            var synologyController = CreateSynologyController();

            // Act
            var getSidResponse = await synologyController.GetSidAsync(fakeUser, fakePassword);

            // Assert
            Assert.IsType<OkObjectResult>(getSidResponse);
            var getsidResult = getSidResponse as OkObjectResult;
            Assert.NotNull(getsidResult.Value);
        }
        #endregion

        #region GetFilesAsync
        [Fact]
        public async Task ShouldHaveInternalServerErrorStatusCodeWhenGetFilesWithNotSuccess()
        {
            // Arrange 
            var faker = new Faker();
            var fakeSid = faker.Random.String2(2);
            var fakePath = faker.Random.String2(2);
            var customSynologyServiceMock = new Mock<ISynologyService>();
            customSynologyServiceMock.Setup(s => s.GetFilesAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(FakerUtils.ErrorSynologyDataFileListResponseFaker.Generate()))
                .Verifiable();
            var synologyController = CreateSynologyController(customSynologyServiceMock.Object);
            var expectedStatusCode = StatusCodes.Status500InternalServerError;

            // Act
            var getFilesResponse = await synologyController.GetFilesAsync(fakeSid, fakePath);

            // Assert
            Assert.IsType<ObjectResult>(getFilesResponse);
            var getFilesResult = getFilesResponse as ObjectResult;
            Assert.Equal(expectedStatusCode, getFilesResult.StatusCode);
        }

        [Fact]
        public async Task ShouldHaveOkStatusCodeWhenGetFiles()
        {
            // Arrange 
            var faker = new Faker();
            var fakeSid = faker.Random.String2(2);
            var fakePath = faker.Random.String2(2);
            var synologyController = CreateSynologyController();

            // Act
            var getFilesResponse = await synologyController.GetFilesAsync(fakeSid, fakePath);

            // Assert
            Assert.IsType<OkObjectResult>(getFilesResponse);
            var getFilesResult = getFilesResponse as OkObjectResult;
            Assert.NotNull(getFilesResult.Value);
        }
        #endregion

        #region DeleteFileAsync
        [Fact]
        public async Task ShouldHaveInternalServerErrorStatusCodeWhenDeleteFileWithNotSuccess()
        {
            // Arrange 
            var faker = new Faker();
            var fakeSid = faker.Random.String2(2);
            var fakePath = faker.Random.String2(2);
            var customSynologyServiceMock = new Mock<ISynologyService>();
            customSynologyServiceMock.Setup(s => s.DeleteFileAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(FakerUtils.ErrorSynologyResponseFaker.Generate()))
                .Verifiable();
            var synologyController = CreateSynologyController(customSynologyServiceMock.Object);
            var expectedStatusCode = StatusCodes.Status500InternalServerError;

            // Act
            var deleteFileResponse = await synologyController.DeleteFileAsync(fakeSid, fakePath);

            // Assert
            Assert.IsType<ObjectResult>(deleteFileResponse);
            var deleteFileResult = deleteFileResponse as ObjectResult;
            Assert.Equal(expectedStatusCode, deleteFileResult.StatusCode);
        }

        [Fact]
        public async Task ShouldHaveOkStatusCodeWhenDeleteFile()
        {
            // Arrange 
            var faker = new Faker();
            var fakeSid = faker.Random.String2(2);
            var fakePath = faker.Random.String2(2);
            var synologyController = CreateSynologyController();

            // Act
            var deleteFileResponse = await synologyController.DeleteFileAsync(fakeSid, fakePath);

            // Assert
            Assert.IsType<OkResult>(deleteFileResponse);
        }
        #endregion
    }
}

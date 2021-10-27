using APISynology.Dtos;
using APISynology.Services;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace APISynology.Tests
{
    public class SynologyServiceTests
    {
        ISynologyService CreateSynologyService() => new SynologyService(_synologyOptions, _httpClient);
        IOptions<SynologySettings> _synologyOptions;
        HttpClient _httpClient;

        public SynologyServiceTests(IOptions<SynologySettings> synologyOptions, IHttpClientFactory httpClientFactory)
        {
            _synologyOptions = synologyOptions;
            _httpClient = httpClientFactory.CreateClient("HttpClientWithSSLUntrusted");
        }

        #region GetTaskListAsync
        [Fact(Skip = "untestable")]
        public async Task ShouldHaveTaskListWhenGetTaskList()
        {
            //TODO use httpclient mock 
            // Arrange
            var synologyService = CreateSynologyService();

            // Act
            var response = await synologyService.GetTaskListAsync();

            // Assert
            Assert.True(response.Success);
        }
        #endregion

        #region GetSIdAsync
        [Fact(Skip ="untestable")]
        public async Task ShouldHaveSidWhenGetSid()
        {
            //TODO use httpclient mock 
            // Arrange
            var user = "";
            var password = "";
            var synologyService = CreateSynologyService();

            // Act
            var response = await synologyService.GetSIdAsync(user, password);

            // Assert
            Assert.True(response.Success);
        }
        #endregion

        #region GetFilesAsync
        [Fact(Skip = "untestable")]
        public async Task ShouldHaveFilesWhenGet()
        {
            //TODO use httpclient mock 
            // Arrange 
            var user = "";
            var password = "";
            var path = _synologyOptions.Value.MusicPath;
            var synologyService = CreateSynologyService();
            var sid = synologyService.GetSIdAsync(user, password).Result.Data.Sid;

            // Act
            var getFilesResponse = await synologyService.GetFilesAsync(sid, path);

            // Assert
            Assert.NotNull(getFilesResponse);
            Assert.True(getFilesResponse.Data.Files.Any());
        }
        #endregion

        #region DeleteFileAsync
        [Fact(Skip = "untestable")]
        public async Task ShouldHaveSucessTrueWhenDeleteFile()
        {
            //TODO use httpclient mock 
            // Arrange 
            var user = "";
            var password = "";
            var path = "";
            var synologyService = CreateSynologyService();
            var sid = synologyService.GetSIdAsync(user, password).Result.Data.Sid;

            // Act
            SynologyResponse deleteFileResponse = await synologyService.DeleteFileAsync(sid, path);

            // Assert
            Assert.NotNull(deleteFileResponse);
            Assert.True(deleteFileResponse.Success);
        }
        #endregion
    }
}

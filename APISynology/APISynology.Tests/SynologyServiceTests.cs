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
            var responsgetFilesResponse = await synologyService.GetFilesAsync(sid, path);

            // Assert
            Assert.NotNull(responsgetFilesResponse);
            Assert.True(responsgetFilesResponse.Data.Files.Any());
        }
        #endregion
    }
}

using APISynology.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISynology.Services
{
    public class SynologyService : ISynologyService
    {
        private readonly SynologySettings _synologySettings;
        private readonly HttpClient _httpClient;

        public SynologyService(IOptions<SynologySettings> synologyOptions, HttpClient httpClient)
        {
            _synologySettings = synologyOptions.Value;
            _httpClient = httpClient;
        }

        ///<inheritdoc />
        public async Task<SynologyResponseWithData<SynologyDataTaskListResponse>> GetTaskListAsync()
        {
            var synologyResponse = new SynologyResponseWithData<SynologyDataTaskListResponse>
            {
                Success = false
            };

            try
            {
                var response = await _httpClient.GetAsync(_synologySettings.TaskListUrl);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = JsonSerializer.Deserialize<SynologyResponseWithData<SynologyDataTaskListResponse>>(stringContent);
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }

        ///<inheritdoc />
        public async Task<SynologyResponseWithData<SynologyDataLoginResponse>> GetSIdAsync(string user, string password)
        {
            var synologyResponse = new SynologyResponseWithData<SynologyDataLoginResponse>
            {
                Success = false
            };

            var url = _synologySettings.BuildLoginUrl(user, password);

            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = (SynologyResponseWithData<SynologyDataLoginResponse>) JsonSerializer.Deserialize(stringContent, typeof(SynologyResponseWithData<SynologyDataLoginResponse>));
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }

        ///<inheritdoc />
        public async Task<SynologyResponseWithData<SynologyDataFileListResponse>> GetFilesAsync(string sid, string path)
        {
            var synologyResponse = new SynologyResponseWithData<SynologyDataFileListResponse>
            {
                Success = false
            };

            var url = _synologySettings.BuildGetFilesUrl(sid, path);

            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = (SynologyResponseWithData<SynologyDataFileListResponse>)JsonSerializer.Deserialize(stringContent, typeof(SynologyResponseWithData<SynologyDataFileListResponse>));
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }

        ///<inheritdoc />
        public async Task<SynologyResponse> DeleteFileAsync(string sid, string path)
        {
            var synologyResponse = new SynologyResponse
            {
                Success = false
            };

            var url = _synologySettings.BuildDeleteFile(sid, path);

            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = (SynologyResponse)JsonSerializer.Deserialize(stringContent, typeof(SynologyResponse));
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }
    }
}

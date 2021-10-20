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

        public async Task<SynologyResponse<SynologyDataTaskListResponse>> GetTaskListAsync()
        {
            var synologyResponse = new SynologyResponse<SynologyDataTaskListResponse>
            {
                Success = false
            };

            try
            {
                var response = await _httpClient.GetAsync(_synologySettings.TaskListUrl);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = JsonSerializer.Deserialize<SynologyResponse<SynologyDataTaskListResponse>>(stringContent);
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }
        
        public async Task<SynologyResponse<SynologyDataLoginResponse>> GetSIdAsync(string user, string password)
        {
            var synologyResponse = new SynologyResponse<SynologyDataLoginResponse>
            {
                Success = false
            };

            var url = _synologySettings.BuildLoginUrl(user, password);

            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = (SynologyResponse<SynologyDataLoginResponse>) JsonSerializer.Deserialize(stringContent, typeof(SynologyResponse<SynologyDataLoginResponse>));
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }

        public async Task<SynologyResponse<SynologyDataFileListResponse>> GetFilesAsync(string sid, string path)
        {
            var synologyResponse = new SynologyResponse<SynologyDataFileListResponse>
            {
                Success = false
            };

            var url = _synologySettings.BuildGetFilesUrl(sid, path);

            try
            {
                var response = await _httpClient.GetAsync(url);
                var stringContent = await response.Content.ReadAsStringAsync();
                synologyResponse = (SynologyResponse<SynologyDataFileListResponse>)JsonSerializer.Deserialize(stringContent, typeof(SynologyResponse<SynologyDataFileListResponse>));
            }
            catch (Exception ex)
            {
                //TODO ajout log dans kibana
            }
            return synologyResponse;
        }
    }
}

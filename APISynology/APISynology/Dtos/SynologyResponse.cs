using System.Text.Json.Serialization;

namespace APISynology.Dtos
{
    public class SynologyResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
    
    public class SynologyResponseWithData<T> : SynologyResponse
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    public class SynologyDataLoginResponse
    {
        [JsonPropertyName("sid")]
        public string Sid { get; set; }
    }
    
    public class SynologyDataTaskListResponse
    {
        [JsonPropertyName("SYNO.API.Auth")]
        public SynologyDataTaskListDetailsResponse SYNOAPIAuth { get; set; }
        [JsonPropertyName("SYNO.DownloadStation.Task")]
        public SynologyDataTaskListDetailsResponse SYNODownloadStationTask { get; set; }
        [JsonPropertyName("SYNO.FileStation.List")]
        public SynologyDataTaskListDetailsResponse SYNOFileStationList { get; set; }
    }

    public class SynologyDataTaskListDetailsResponse
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("minVersion")]
        public int MinVersion { get; set; }
        [JsonPropertyName("maxVersion")]
        public int MaxVersion { get; set; }
    }
    
    public class SynologyDataFileListResponse
    {
        [JsonPropertyName("files")]
        public SynologyDataFileResponse[] Files { get; set; }
    }
    public class SynologyDataFileResponse
    {
        [JsonPropertyName("isdir")]
        public bool IsDir { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}

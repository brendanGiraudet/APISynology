using System.Text.Encodings.Web;
using System.Web;

namespace APISynology.Dtos
{
    public class SynologySettings
    {
        public string User { get; set; }
        
        public string Password { get; set; }
        
        public string BaseUrl { get; set; }
        
        public string LoginPath { get; set; }
        public string BuildLoginUrl(string user, string password)
        {
            return BuildPath(string.Format(LoginPath, user, password));
        }

        public string TaskListPath { get; set; }
        public string TaskListUrl => BuildPath(TaskListPath);

        public string GetFilesPath { get; set; }
        public string BuildGetFilesUrl(string sid, string path)
        {
            return BuildPath(string.Format(GetFilesPath, sid, HttpUtility.UrlEncode(path)));
        }
        
        public string DeleteFilePath { get; set; }
        public string BuildDeleteFile(string sid, string path)
        {
            return BuildPath(string.Format(DeleteFilePath, sid, HttpUtility.UrlEncode(path)));
        }

        public string MusicPath { get; set; }

        public string BuildPath(string path)
        {
            return $"{BaseUrl}{path}";
        }
    }
}

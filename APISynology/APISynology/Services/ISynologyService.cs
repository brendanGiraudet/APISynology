using APISynology.Dtos;
using System.Threading.Tasks;

namespace APISynology.Services
{
    public interface ISynologyService
    {
        /// <summary>
        /// Send a request to the DSM to get session id
        /// </summary>
        /// <param name="user">Login use to log in DSM</param>
        /// <param name="password">Password use to log in DSM</param>
        /// <returns>Session id</returns>
        Task<SynologyResponseWithData<SynologyDataLoginResponse>> GetSIdAsync(string user, string password);

        /// <summary>
        /// Send a request to the DSM to get task list
        /// </summary>
        /// <returns>List of the task details</returns>
        Task<SynologyResponseWithData<SynologyDataTaskListResponse>> GetTaskListAsync();

        /// <summary>
        /// Send a request to the DSM to get files from the path
        /// </summary>
        /// <param name="sid">Session id of the connected user</param>
        /// <param name="path">Path of the directory where get files</param>
        /// <returns>List of the files details</returns>
        Task<SynologyResponseWithData<SynologyDataFileListResponse>> GetFilesAsync(string sid, string path);

        /// <summary>
        /// Send a request to the DSM to delete specific file from the path
        /// </summary>
        /// <param name="sid">Session id of the connected user</param>
        /// <param name="path">Path of the directory where delete file</param>
        /// <returns></returns>
        Task<SynologyResponse> DeleteFileAsync(string sid, string path);
    }
}

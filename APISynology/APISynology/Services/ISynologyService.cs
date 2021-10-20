using APISynology.Dtos;
using System.Threading.Tasks;

namespace APISynology.Services
{
    public interface ISynologyService
    {
        Task<SynologyResponse<SynologyDataLoginResponse>> GetSIdAsync(string user, string password);
        Task<SynologyResponse<SynologyDataTaskListResponse>> GetTaskListAsync();
        Task<SynologyResponse<SynologyDataFileListResponse>> GetFilesAsync(string sid, string path);
    }
}

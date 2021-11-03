using APISynology.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APISynology.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynologyController : ControllerBase
    {
        private readonly ISynologyService _synologyService;

        public SynologyController(ISynologyService synologyService)
        {
            _synologyService = synologyService;
        }

        [HttpGet]
        [Route("/sid")]
        public async Task<IActionResult> GetSidAsync([FromQuery] string user, [FromQuery] string password)
        {
            var getSidResponse = await _synologyService.GetSIdAsync(user, password);

            if (!getSidResponse.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Code : {getSidResponse.Error.Code}");

            return Ok(getSidResponse.Data.Sid);
        }
        
        [HttpGet]
        [Route("/files")]
        public async Task<IActionResult> GetFilesAsync([FromQuery] string sid, [FromQuery] string path)
        {
            var getFilesAsyncResponse = await _synologyService.GetFilesAsync(sid, path);

            if (!getFilesAsyncResponse.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Code : {getFilesAsyncResponse.Error.Code}");

            return Ok(getFilesAsyncResponse.Data);
        }
        
        [HttpDelete]
        [Route("/files")]
        public async Task<IActionResult> DeleteFileAsync([FromQuery] string sid, [FromQuery] string path)
        {
            var deleteFileAsyncResponse = await _synologyService.DeleteFileAsync(sid, path);

            if (!deleteFileAsyncResponse.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Code : {deleteFileAsyncResponse.Error.Code}");

            return Ok();
        }
    }
}

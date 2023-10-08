using CapPlacement.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyPreviewServiceController : ControllerBase
    {
        private readonly IPreviewService _previewService;

        public MyPreviewServiceController(IPreviewService previewService)
        {
            _previewService = previewService;
        }

        [HttpGet("GetPreview")]
        public async Task<IActionResult> GetPreviewAsync([FromQuery] string programTitle)
        {
            var response = await _previewService.GetProgramPreviewAsync(programTitle);
            return response.Status ? Ok(response) : BadRequest(response.Message);
        }
    }
}

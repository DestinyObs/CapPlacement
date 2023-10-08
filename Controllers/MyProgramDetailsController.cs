using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CapPlacement.Interfaces.Services;
using CapPlacement.DTOs.RequestModels;

namespace WebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyProgramDetailsController : ControllerBase
    {
        private readonly IMyProgramDetailsService _programDetailsService;

        public MyProgramDetailsController(IMyProgramDetailsService programDetailsService)
        {
            _programDetailsService = programDetailsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProgramAsync([FromBody] CreateProgram programRequestModel)
        {
            var response = await _programDetailsService.AddProgramAsync(programRequestModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetProgramAsync([FromQuery] string Id)
        {
            var response = await _programDetailsService.GetProgramAsync(Id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProgramsAsync()
        {
            var response = await _programDetailsService.GetAllProgramsAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProgramAsync([FromBody] UpdateProgram updateProgram, [FromQuery] string programId)
        {
            var response = await _programDetailsService.EditProgramAsync(updateProgram, programId);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteStageAsync([FromQuery] string id)
        {
            var response = await _programDetailsService.DeleteProgramAsync(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}

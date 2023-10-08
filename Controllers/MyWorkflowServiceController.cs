using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CapPlacement.DTOs.RequestModels;
using CapPlacement.Interfaces.Services;
using CapPlacement.DTOs.RequestModels.Stage;

namespace WebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyWorkflowServiceController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;

        public MyWorkflowServiceController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpPost("CreateStage")]
        public async Task<IActionResult> CreateStageAsync(CreateStage stageRequestModel)
        {
            var response = await _workflowService.CreateStageAsync(stageRequestModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetStage")]
        public async Task<IActionResult> GetStageAsync(string Id)
        {
            var response = await _workflowService.GetStageAsync(Id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetStages")]
        public async Task<IActionResult> GetStagesAsync()
        {
            var response = await _workflowService.GetStagesAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateUsualStage")]
        public async Task<IActionResult> UpdateUsualStageAsync([FromBody] UpdateUsualStage updateUsualStage, [FromQuery] string stageName)
        {
            var response = await _workflowService.UpdateUsualStageAsync(updateUsualStage, stageName);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateVideoInterviewStage")]
        public async Task<IActionResult> UpdateVideoInterviewStageAsync([FromBody] UpdateVideoInterviewStage updateVideoInterviewStage, [FromQuery] string stageName)
        {
            var response = await _workflowService.UpdateVideoInterviewStageAsync(updateVideoInterviewStage, stageName);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteStage")]
        public async Task<IActionResult> DeleteStageAsync([FromQuery] string id)
        {
            var response = await _workflowService.DeleteStageAsync(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CapPlacement.Interfaces.Services;
using CapPlacement.DTOs.RequestModels;

namespace CapPlacement.Controllers
{
    /// <summary>
    /// Controller responsible for handling application-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MyApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        /// <summary>
        /// Constructor injection for the application service.
        /// </summary>
        /// <param name="applicationService">The application service.</param>
        public MyApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateApplicationAsync([FromBody] CreateApplication applicationModel)
        {
            var response = await _applicationService.CreateApplicationAsync(applicationModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Retrieves a single application by its ID.
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetApplicationAsync(string Id)
        {
            var response = await _applicationService.GetApplicationAsync(Id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Retrieves all applications.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetApplicationsAsync()
        {
            var response = await _applicationService.GetApplicationsAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Updates an application by its ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationAsync([FromBody] UpdateApplication updateApplicationModel, [FromRoute] string id)
        {
            var response = await _applicationService.UpdateApplicationAsync(updateApplicationModel, id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Deletes an application by its ID.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteApplicationAsync([FromQuery] string id)
        {
            var response = await _applicationService.DeleteApplicationAsync(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Creates a new question.
        /// </summary>
        [HttpPost("question")]
        public async Task<IActionResult> CreateQuestionAsync([FromBody] BaseQuestionRequestModel requestModel)
        {
            var response = await _applicationService.CreateQuestionAsync(requestModel);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Retrieves a single question by its ID.
        /// </summary>
        [HttpGet("question/{Id}")]
        public async Task<IActionResult> GetQuestionAsync(string Id)
        {
            var response = await _applicationService.GetQuestionAsync(Id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Retrieves all questions.
        /// </summary>
        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestionsAsync()
        {
            var response = await _applicationService.GetQuestionsAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Updates a question by its ID.
        /// </summary>
        [HttpPut("question/{id}")]
        public async Task<IActionResult> UpdateQuestionAsync([FromBody] UpdateQuestionModel updateQuestionModel, [FromRoute] string id)
        {
            var response = await _applicationService.UpdateQuestionAsync(updateQuestionModel, id);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// Deletes a question by its ID.
        /// </summary>
        [HttpDelete("question")]
        public async Task<IActionResult> DeleteQuestionAsync([FromQuery] string id)
        {
            var response = await _applicationService.DeleteQuestionAsync(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}

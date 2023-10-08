using System.Threading.Tasks;
using System.Collections.Generic;
using CapPlacement.DTOs.RetrievalModels;
using CapPlacementTOs.RetrievalModels;
using CapPlacement.DTOs.RequestModels.Stage;
using CapPlacement.DTOs.RequestModels;

namespace CapPlacement.Interfaces.Services
{
    public interface IWorkflowService
    {
        Task<BaseResponse<bool>> CreateStageAsync(CreateStage stageRequestModel);
        Task<BaseResponse<bool>> UpdateUsualStageAsync(UpdateUsualStage stageUpdateRequestModel, string stageName);
        Task<BaseResponse<bool>> UpdateVideoInterviewStageAsync(UpdateVideoInterviewStage stageUpdateRequestModel, string stageName);
        Task<BaseResponse<IEnumerable<StageModel>>> GetStagesAsync();
        Task<BaseResponse<StageModel>> GetStageAsync(string Id);
        Task<BaseResponse<bool>> DeleteStageAsync(string Id);
    }
}
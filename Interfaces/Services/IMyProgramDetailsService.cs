
using System.Threading.Tasks;
using System.Collections.Generic;
using CapPlacement.DTOs.RequestModels;
using CapPlacement.DTOs.RetrievalModels;
using CapPlacementTOs.RetrievalModels;

namespace CapPlacement.Interfaces.Services
{
    public interface IMyProgramDetailsService
    {
        Task<BaseResponse<bool>> AddProgramAsync(CreateProgram programModel);
        Task<BaseResponse<bool>> EditProgramAsync(UpdateProgram programModel, string programTitle);
        Task<BaseResponse<IEnumerable<ProgramModel>>> GetAllProgramsAsync();
        Task<BaseResponse<ProgramModel>> GetProgramAsync(string Id);
        Task<BaseResponse<ProgramModel>> GetProgramByTitleAsync(string programTitle);
        Task<BaseResponse<bool>> DeleteProgramAsync(string Id);
    }
}

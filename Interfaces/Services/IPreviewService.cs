using System.Threading.Tasks;
using CapPlacement.DTOs.RetrievalModels;
using CapPlacementTOs.RetrievalModels;

namespace CapPlacement.Interfaces.Services
{
    public interface IPreviewService
    {
        Task<BaseResponse<PreviewServiceModel>> GetProgramPreviewAsync(string programTitle);
    }
}
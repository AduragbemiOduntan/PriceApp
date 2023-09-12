using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IMaterialEstimateService
    {
        //Material Estimate for specific products
        Task<StandardResponse<MaterialEstimateResponseDto>> CreatePegMEService(double buidingSetbackPermeter, string stage, int uniqueProjectId);
        Task<StandardResponse<MaterialEstimateResponseDto>> GetMEByUniqueProjectIdAndStageAsync(int uniqueProjectId, string stage);
        Task<StandardResponse<ICollection<MaterialEstimateResponseDto>>> GetAllMaterialEstimateAsync();
        Task<StandardResponse<StripFoundationBaseCastingResponseDto>> CreateFoundationBaseCastingAsync(double girth);
        Task<StandardResponse<StripFoundationReinforcementResponseDto>> CreateFoundationReinforcementAsync(double girth);
        // General

    }
}

using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;

namespace PriceApp_Application.Services.Interfaces
{
    public interface ISubStructureEstimateService
    {
        Task<StandardResponse<MaterialEstimateResponseDto>> GetSubStructureByAppelationAndStageAsync(string appellation, string stage);
        Task<StandardResponse<StripFoundationBaseCastingResponseDto>> CreateFoundationBaseCastingAsync(double girth, string appellation);
        Task<StandardResponse<StripFoundationColumAndReinforcementResponseDto>> CreateFoundationColumnAndReinforcementAsync(double girth, string appellation);
        Task<StandardResponse<StripFoundationBlockworkResponseDto>> CreateFoundationBlockWorkAsync(double girth, string appellation);
        Task<StandardResponse<StripFoundationBackfillingResponseDto>> CreateFoundationBackfillingAsync(double buildingLength, double buildingBreath, string appellation);
        Task<StandardResponse<GermanFloorDto>> CreateGermanFloorAsync(double buildingLength, double buildingBreath, string appellation);
    }
}

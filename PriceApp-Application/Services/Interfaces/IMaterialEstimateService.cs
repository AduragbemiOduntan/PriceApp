using PriceApp_Domain.Dtos.Responses;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IMaterialEstimateService
    {
        //Material Estimate for specific products
        Task<StandardResponse<MaterialEstimateResponseDto>> GetMaterialEstimateByAppelationAndStageAsync(string appellation, string stage);
        Task<StandardResponse<ICollection<MaterialEstimateResponseDto>>> GetAllMaterialEstimateAsync();
    }
}

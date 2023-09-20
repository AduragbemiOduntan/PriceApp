using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.stages;

namespace PriceApp_Application.Services.Interfaces
{
    public interface ISuperStructureEstimateService
    {
        Task<StandardResponse<BuildingWallBlockworkDto>> CreateBuildingWallBlockWorkAsync(double girth, double buildingFloorHeight, string appellation);
        Task<StandardResponse<LintelDto>> CreateLintelAsync(double girth, string appellation);
        Task<StandardResponse<BuildingWallColumnDto>> CreateWallColumnAsync(double girth, double wallHeight, string appellation);
    }
}

using PriceApp_Domain.Dtos.Responses;

namespace PriceApp_Application.Services.Interfaces
{
    public interface ISettingOutStageService
    {
        Task<StandardResponse<SettingOutStageResponseDto>> CreateSettingOutAsync(double buidingSetbackPerimeter, string stage, string state, string appellation);
        Task<StandardResponse<SettingOutStageResponseDto>> GetSettingOutByAppellationAsync(string stage, string appellation);
        Task<StandardResponse<ICollection<SettingOutStageResponseDto>>> GetAllSettingOutAsync();
    }
}

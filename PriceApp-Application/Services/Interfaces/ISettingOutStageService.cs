using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Interfaces
{
    public interface ISettingOutStageService
    {
        Task<StandardResponse<SettingOutStageResponseDto>> CreateSettingOutAsync(double buidingSetbackPerimeter, string stage, int uniqueProjectId);
        Task<StandardResponse<SettingOutStageResponseDto>> GetSettingOutByProjectIdAsync(int uniqueProjectId);
        Task<StandardResponse<ICollection<SettingOutStageResponseDto>>> GetAllSettingOutAsync();

        /*Task<StandardResponse<SettingOutStageResponseDto>> CreateSettingOutStageEstimate(SettingOutStageRequestDto settingOutStageRequest, double buildinSetbackPerimeter, int uniqueProjectId);*/
    }
}

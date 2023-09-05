using PriceApp_Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Interfaces
{
   public interface IEscavationService
    {
        Task<StandardResponse<EscavationResponseDto>> CreateEscavationAsync(double girth, int uniqueProjectId);
    }
}

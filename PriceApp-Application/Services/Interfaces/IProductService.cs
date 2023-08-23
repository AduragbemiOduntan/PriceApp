using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<StandardResponse<ProductResponseDto>> CreateProduct(ProductRequestDto productRequest);

    }
}

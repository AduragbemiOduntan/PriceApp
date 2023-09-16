using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Shared.RequestFeatures;
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
        Task<StandardResponse<IEnumerable<ProductResponseDto>>> GetAllProductAsync(ProductParameters productParameters);
        Task<StandardResponse<ProductResponseDto>> GetProductByIdAsync(int id, bool trackChanges);
        Task<StandardResponse<ProductResponseDto>> GetProductByNameAsync(string productName, bool trackChanges);
        Task<StandardResponse<ProductUpdateResponseDto>> UpdateProductUnitPriceAsync(ProductUpdateRequestDto productRequest, int id, bool trackChanges);
        Task<StandardResponse<Product>> DeleteProductAsync(int id, bool trackChanges);
        Task<StandardResponse<IEnumerable<ProductResponseDto>>> GetProductByKeyWordAsync(string keyword, bool track);
    }
}

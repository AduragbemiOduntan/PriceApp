using Microsoft.AspNetCore.Http;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Shared.RequestFeatures;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<StandardResponse<ProductResponseDto>> CreateProduct(ProductRequestDto productRequest);
        Task<StandardResponse<(IEnumerable<ProductResponseDto> products, MetaData metaData)>> GetAllProductAsync(ProductParameters productParameters);
        Task<StandardResponse<ProductResponseDto>> GetProductByIdAsync(int id);
        Task<StandardResponse<ProductResponseDto>> GetProductByNameAsync(string productName);
        Task<StandardResponse<ProductUpdateResponseDto>> UpdateProductUnitPriceAsync(ProductUpdateRequestDto productRequest, int id);
        Task<StandardResponse<Product>> DeleteProductAsync(int id);
        Task<StandardResponse<IEnumerable<ProductResponseDto>>> GetProductByKeyWordAsync(string keyword);
        Task<StandardResponse<(IEnumerable<ProductResponseDto>, ProductStatePriceDto)>> GetProductPriceByStateAsync(string productName, string state);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(int productId, IFormFile file);
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Implementation;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Shared.RequestFeatures;
using System.Text.Json;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create new product. Take product DTO as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(ProductRequestDto productRequest)
        {
            var result = await _productService.CreateProduct(productRequest);
            return Ok(result);
        }

        /// <summary>
        /// Get all created products. Default pagination page number = 1, page size = 10
        /// </summary>
        /*[Authorize]*/
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery]ProductParameters productParameters)
        {
            var result = await _productService.GetAllProductAsync(productParameters);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.Data.metaData));
            return Ok(result.Data.products);
        }

        /// <summary>
        /// Get a single product by ID. Takes user ID as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get product by product name. Takes product name as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpGet("productname")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            var result = await _productService.GetProductByNameAsync(productName);
            return Ok(result);
        }

        /// <summary>
        /// Update a single product by ID. Takes product ID as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductUpdateRequestDto productRequest, int id)
        {
            var result = await _productService.UpdateProductUnitPriceAsync(productRequest, id);
            return Ok(result);
        }

        /* [Authorize]*/
        /*        [HttpGet("keyword")]
                public async Task<IActionResult> GetProductByKeyWord(string keyword)
                {
                    var result = await _productService.GetProductByKeyWordAsync(keyword);
                    return Ok(result);
                }*/

        /*[Authorize] */
        /*         [HttpGet("byState")]
                public async Task<IActionResult> GetProductPriceByState(string productName, string state)
                {
                    var result = await _productService.GetProductPriceByStateAsync(productName, state);
                    return Ok(result);
                }*/



        /*        [HttpPost("image/{id}")]
                public IActionResult UploadProfilePic(int productId, IFormFile file)
                {
                    var result = _productService.UploadProfileImage(productId, file);
                    if (result.Result.Succeeded)
                    {
                        return Ok(new { ImageUrl = result.Result.Data.Item2 });
                    }
                    return NotFound();
                }*/

        /*        [HttpDelete]
                public async Task<IActionResult> DeleteProduct(int id, bool trackChanges)
                {
                    var result = await _productService.DeleteProductAsync(id, trackChanges);
                    return Ok(result);
                }*/
    }
}

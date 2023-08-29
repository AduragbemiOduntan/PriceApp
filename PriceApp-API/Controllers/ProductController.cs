using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;

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

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductRequestDto productRequest)
        {
            var result = await _productService.CreateProduct(productRequest);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProduct(bool trackChanges)
        {
            var result = await _productService.GetAllProductAsync(trackChanges);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id, bool trackChanges)
        {
            var result = await _productService.GetProductByIdAsync(id,trackChanges);
            return Ok(result);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetProductByName(string productName, bool trackChanges)
        {
            var result = await _productService.GetProductByNameAsync(productName, trackChanges);
            return Ok(result);
        }
        [HttpGet("word")]
        public async Task<IActionResult> GetProductByKeyWord(string keyword, bool track)
        {
            var result = await _productService.GetProductByKeyWordAsync(keyword, track);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductUpdateRequestDto productRequest, int id, bool trackChanges)
        {
            var result = await _productService.UpdateProductUnitPriceAsync(productRequest, id, trackChanges);
            return Ok(result);
        }

/*        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id, bool trackChanges)
        {
            var result = await _productService.DeleteProductAsync(id, trackChanges);
            return Ok(result);
        }*/
    }
}

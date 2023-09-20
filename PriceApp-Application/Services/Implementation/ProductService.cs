using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using PriceApp_Shared.RequestFeatures;

namespace PriceApp_Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<StandardResponse<ProductResponseDto>> CreateProduct(ProductRequestDto productRequest)
        {
            if (productRequest == null)
            {
                _logger.LogError("Product details cannot be empty");
                return StandardResponse<ProductResponseDto>.Failed("Product creation failed");
            }
            _logger.LogInformation($"Attemping to create a product {DateTime.Now}");

            /*   var state = GetStateOptions();*/
            var newProduct = _mapper.Map<Product>(productRequest);

            _unitOfWork.Product.Create(newProduct);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<ProductResponseDto>(newProduct);
            return StandardResponse<ProductResponseDto>.Success($"Product successfully created {newProduct.ProductName}", productToReturn);
        }

        public async Task<StandardResponse<(IEnumerable<ProductResponseDto> products, MetaData metaData)>> GetAllProductAsync(ProductParameters productParameters)
        {
            _logger.LogInformation($"Attempting to get products {DateTime.Now}");
            var productsWithMetaData = await _unitOfWork.Product.FindAllProduct(productParameters);

            if (productsWithMetaData == null)
            {
                _logger.LogError("No product exist");
                return StandardResponse<(IEnumerable<ProductResponseDto> product, MetaData metaData)>.Failed($"Product do not exist");
            }

            var productsReturned = _mapper.Map<IEnumerable<ProductResponseDto>>(productsWithMetaData);
            return StandardResponse<(IEnumerable<ProductResponseDto> product, MetaData metaData)>
                .Success($"Products successfully retrieved", (products: productsReturned, metaData: productsWithMetaData.MetaData));
        }

        public async Task<StandardResponse<ProductResponseDto>> GetProductByIdAsync(int id)
        {
            if (id == null)
            {
                _logger.LogError("Id field cannot be empty");
                return StandardResponse<ProductResponseDto>.Failed("Id field cannot be empty");
            }

            _logger.LogInformation($"Attempting to get Product with id {id} {DateTime.Now}");
            var product = await _unitOfWork.Product.FindProductById(id);

            if (product == null)
            {
                _logger.LogError($"Product does not exit");
                return StandardResponse<ProductResponseDto>.Failed($"Product does not exist");
            }
            var productReturned = _mapper.Map<ProductResponseDto>(product);
            return StandardResponse<ProductResponseDto>.Success($"Product successfully retrieved", productReturned);
        }

        public async Task<StandardResponse<ProductResponseDto>> GetProductByNameAsync(string productName)
        {
            if (productName == null)
            {
                _logger.LogError("Product name field cannot be empty");
                return StandardResponse<ProductResponseDto>.Failed("Product field cannot be empty");
            }

            _logger.LogInformation($"Attempting to get Product with product name {productName} {DateTime.Now}");
            var product = await _unitOfWork.Product.FindProductByName(productName);

            if (product == null)
            {
                _logger.LogError($"Product does not exit");
                return StandardResponse<ProductResponseDto>.Failed($"Product does not exist");
            }
            var productReturned = _mapper.Map<ProductResponseDto>(product);
            return StandardResponse<ProductResponseDto>.Success($"Product successfully retrieved", productReturned);
        }
        public async Task<StandardResponse<ProductUpdateResponseDto>> UpdateProductUnitPriceAsync(ProductUpdateRequestDto productRequest, int id)
        {
            if (id == null)
            {
                _logger.LogError("Id field cannot be empty");
                return StandardResponse<ProductUpdateResponseDto>.Failed("Id field cannot be empty");
            }

            if (productRequest == null)
            {
                _logger.LogError("Product details cannot be empty");
                return StandardResponse<ProductUpdateResponseDto>.Failed("Product update failed");
            }

            _logger.LogInformation($"Attemping to update a product {DateTime.Now}");
            var product = await _unitOfWork.Product.FindProductById(id);
            if (product == null)
            {
                _logger.LogError($"Product with ID {id} not found");
                return StandardResponse<ProductUpdateResponseDto>.Failed($"Product with ID {id} not found");
            }
            var newProduct = _mapper.Map(productRequest, product);

            _unitOfWork.Product.Update(newProduct);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<ProductUpdateResponseDto>(newProduct);
            return StandardResponse<ProductUpdateResponseDto>.Success($"Product successfully updated", productToReturn);
        }

        public async Task<StandardResponse<Product>> DeleteProductAsync(int id)
        {
            if (id == null)
            {
                _logger.LogError($"Id field cannot be empty");
                return StandardResponse<Product>.Failed("Id field cannot be empty");
            }
            var product = await _unitOfWork.Product.FindProductById(id);

            if (product == null)
            {
                _logger.LogError($"User does not exit");
                return StandardResponse<Product>.Failed($"The user with Id {id} does not exist");
            }
            _unitOfWork.Product.Delete(product);
            await _unitOfWork.SaveAsync();
            return StandardResponse<Product>.Success($"Delete successful", product);
        }

        public async Task<StandardResponse<(IEnumerable<ProductResponseDto>, ProductStatePriceDto)>> GetProductPriceByStateAsync(string productName, string state)
        {
            double price = 0;
            byte counter = 0;
            var products = await _unitOfWork.Product.FindProductByState(productName, state);
            var productPrices = new List<double>();

            foreach (var product in products)
            {
                price += product.UnitPrice;
                counter++;
            }
            var averagePrice = price / counter;

            var newProduct = _mapper.Map<IEnumerable<ProductResponseDto>>(productPrices);
            var statePrice = new ProductStatePriceDto();
            statePrice.StateLowestPrice = productPrices.Min();
            statePrice.StateHighestPrice = productPrices.Max();
            statePrice.StateAveragePrice = averagePrice;

            return StandardResponse<(IEnumerable<ProductResponseDto>, ProductStatePriceDto)>
                .Success($"{products.ToList().ElementAt(1).State }", (newProduct, statePrice));
        }

        public async Task<StandardResponse<IEnumerable<ProductResponseDto>>> GetProductByKeyWordAsync(string keyword)
        {
            if (keyword == null)
            {
                _logger.LogError($"Keyword field cannot be empty");
                return StandardResponse<IEnumerable<ProductResponseDto>>.Failed("Keyword field cannot be empty");
            }

            _logger.LogInformation("Attempting to get rpoducts");
            var products = await _unitOfWork.Product.FindProductByKeyWord(keyword);
            if (products == null)
            {
                _logger.LogError("No product exist");
                return StandardResponse<IEnumerable<ProductResponseDto>>.Failed($"Product do not exist");
            }
            var productsToReturn = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

            return StandardResponse<IEnumerable<ProductResponseDto>>.Success($"Successfully retrieve products that match keyword", productsToReturn);
        }

        public async Task<StandardResponse<(bool, string)>> UploadProfileImage(int productId, IFormFile file)
        {
            var result = await _unitOfWork.Product.FindProductById(productId);

            if (result is null)
            {
                _logger.LogWarning($"No product with id {productId}");

                return StandardResponse<(bool, string)>.Failed("Product not found", 99);
            }

            var product = _mapper.Map<Product>(result);

            string url = _photoService.AddPhotoForUser(file);

            if (string.IsNullOrWhiteSpace(url))

                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);

            product.ImageUrl = url;

            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (true, url), 204);
        }
    }
}


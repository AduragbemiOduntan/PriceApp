using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StandardResponse<ProductResponseDto>> CreateProduct(ProductRequestDto productRequest)
        {
            if(productRequest == null)
            {
                _logger.LogError("Product details cannot be empty");
                return StandardResponse<ProductResponseDto>.Failed("Product creation failed");
            }
            _logger.LogInformation($"Attemping to create a product {DateTime.Now}");
            var newProduct = _mapper.Map<Product>(productRequest);
            _unitOfWork.Product.Create(newProduct);
            await _unitOfWork.SaveAsync();
            var productToReturn = _mapper.Map<ProductResponseDto>(newProduct);
            return StandardResponse<ProductResponseDto>.Success($"Product successfully created {newProduct.ProductName}", productToReturn);
        }


    }
}

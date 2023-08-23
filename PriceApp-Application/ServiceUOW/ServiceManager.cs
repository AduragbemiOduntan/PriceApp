/*using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Implementation;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.ServiceUOW
{
    public class ServiceManager
    {
        private IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        UserManager<User> _userManager;

        public ServiceManager(IUnitOfWork unitOfWork, ILogger<> logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;
        }

        public IProductService Product => _productService ??= new ProductService(_unitOfWork, logger, mapper);
    }
}
*/
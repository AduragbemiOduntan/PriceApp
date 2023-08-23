using AutoMapper;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Common
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<UserRequestDto, UserResponseDto>();
            CreateMap<UserResponseDto, UserResponseDto>();
        }
    }
}

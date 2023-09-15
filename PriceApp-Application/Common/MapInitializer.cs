using AutoMapper;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Dtos.Responses.materials;
using PriceApp_Domain.Dtos.Responses.stages;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Common
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();

            CreateMap<ProductUpdateRequestDto, Product>();
            CreateMap<Product, ProductUpdateResponseDto>();

            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserResponseDto>();

            CreateMap<MaterialEstimateRequestDto, MaterialEstimate>();
            CreateMap<MaterialEstimate, MaterialEstimateResponseDto>();

            CreateMap<SettingOutStageRequestDto, SettingOutStage>();
            CreateMap<SettingOutStage, SettingOutStageResponseDto>();

            CreateMap<ExcavationRequestDto, Excavation>();
            CreateMap<Excavation, ExcavationResponseDto>();

            CreateMap<FoundationBaseCastingRequestDto, StripFoundationBaseCastingResponseDto>();
            CreateMap<StripFoundationColumAndReinforcementResponseDto, StripFoundationColumAndReinforcementResponseDto>();
            CreateMap<StripFoundationBlockworkResponseDto, StripFoundationBlockworkResponseDto>();
            CreateMap<StripFoundationBackfillingResponseDto, StripFoundationBackfillingResponseDto>();
            CreateMap<GermanFloorDto,GermanFloorDto>();

           /* CreateMap<StripFoundationReinforcementResponseDto, StripFoundationReinforcementResponseDto>();*/
           CreateMap<Product, MaterialDto>();
            CreateMap<MaterialDto, MaterialEstimate>();
        }
    }
}

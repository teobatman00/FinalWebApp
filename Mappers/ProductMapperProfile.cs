using AutoMapper;
using FinalWebApp.Dto.Requests.Product;
using FinalWebApp.Dto.Responses.Product;
using FinalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Mappers
{
    public class ProductMapperProfile: Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductCreateRequest, ProductEntity>()
                .ForSourceMember(s => s.CategoryId, y => y.DoNotValidate())
                .ForSourceMember(s => s.OrdersId, y => y.DoNotValidate());
            CreateMap<ProductUpdateRequest, ProductEntity>()
                .ForSourceMember(s => s.CategoryId, y => y.DoNotValidate())
                .ForSourceMember(s => s.OrdersId, y => y.DoNotValidate());
            CreateMap<ProductEntity, ProductGetListResponse>()
                .ForMember(dest => dest.Category, source => source.MapFrom(s => s.Category));
            CreateMap<ProductEntity, ProductGetDetailResponse>();
        }
    }
}

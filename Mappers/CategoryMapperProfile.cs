using AutoMapper;
using FinalWebApp.Dto.Requests.Category;
using FinalWebApp.Dto.Responses.Category;
using FinalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Mappers
{
    public class CategoryMapperProfile: Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<CategoryCreateRequest, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryGetListResponse>()
                .ForSourceMember(s => s.Description, y => y.DoNotValidate());
            CreateMap<CategoryEntity, CategoryGetDetailResponse>();

        }

    }
}

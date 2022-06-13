using AutoMapper;
using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Mappers
{
    public class OrderMapperProfile: Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderCreateRequest, OrderEntity>();
            CreateMap<OrderUpdateRequest, OrderEntity>();
            CreateMap<OrderEntity, OrderGetListResponse>();
            CreateMap<OrderEntity, OrderGetDetailResponse>();
        }

    }
}

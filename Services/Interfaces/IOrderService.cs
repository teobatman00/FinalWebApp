using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;

namespace FinalWebApp.Services.Interfaces;

public interface IOrderService: IGetListService<OrderGetListResponse, BaseQueryFilter>,
    IGetDetailService<string, OrderGetDetailResponse>,
    ICreateService<OrderCreateRequest, bool>,
    IUpdateService<string, OrderUpdateRequest, bool>,
    IDeleteService<string, bool>
{
    
}
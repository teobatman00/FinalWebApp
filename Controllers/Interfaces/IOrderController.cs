using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers.Interfaces;

public interface IOrderController: IGetDetailController<string, OrderGetDetailResponse>,
    IGetListController<OrderGetListResponse, BaseQueryFilter>,
    ICreateController<OrderCreateRequest, bool>,
    IUpdateController<string, OrderUpdateRequest, bool>,
    IDeleteController<string, bool>
{
    
}
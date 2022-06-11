using AutoMapper;
using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class OrderService: BaseService<OrderService>, IOrderService
{
    private IOrderRepository orderRepository;

    public OrderService(IMapper mapper, ILogger<OrderService> logger, IOrderRepository orderRepository) : base(mapper, logger)
    {
        this.orderRepository = orderRepository;
    }

    public Task<ApiResponse<bool>> CreateAsync(OrderCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<OrderGetDetailResponse>> GetDetailAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<PagePagination<OrderGetListResponse>>> GetListAsync(BaseQueryFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> UpdateAsync(string id, OrderUpdateRequest request)
    {
        throw new NotImplementedException();
    }
}
using AutoMapper;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class OrderService: BaseService<OrderService>, IOrderService
{
    public OrderService(IMapper mapper, ILogger<OrderService> logger) : base(mapper, logger)
    {
    }
}
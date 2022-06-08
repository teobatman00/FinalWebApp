using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;

namespace FinalWebApp.Repositories;

public class OrderRepository: BaseRepository<OrderRepository, OrderEntity, string>, IOrderRepository
{
    public OrderRepository(ILogger<OrderRepository> logger, ApplicationContext context) : base(logger, context)
    {
    }
}
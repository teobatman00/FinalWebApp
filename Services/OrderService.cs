using AutoMapper;
using FinalWebApp.Dto.Requests.Order;
using FinalWebApp.Dto.Responses.Order;
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class OrderService: BaseService<OrderService>, IOrderService
{
    private IOrderRepository orderRepository;
    private IProductRepository productRepository;

    public OrderService(IMapper mapper, ILogger<OrderService> logger, IOrderRepository orderRepository, IProductRepository productRepository) : base(mapper, logger)
    {
        this.orderRepository = orderRepository;
        this.productRepository = productRepository;
    }

    public async Task<ApiResponse<bool>> CreateAsync(OrderCreateRequest request)
    {
        var productEntity = await productRepository.GetByIdAsync(request.ProductId);
        if (productEntity is null)
            throw new NotFoundDataException($"Order {request.ProductId} is not found");
        var entity = _mapper.Map<OrderCreateRequest, OrderEntity>(request);
        entity.Product = productEntity;
        await orderRepository.SaveAsync(entity);
        return new ApiResponse<bool>().Success(true);
    }

    public async Task<ApiResponse<bool>> DeleteAsync(string id)
    {
        var entity = await orderRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException($"Order {id} is not available");
        await orderRepository.DeleteAsync(entity);
        return new ApiResponse<bool>().Success(true);
    }

    public Task<ApiResponse<OrderGetDetailResponse>> GetDetailAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<PagePagination<OrderGetListResponse>>> GetListAsync(BaseQueryFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<bool>> UpdateAsync(string id, OrderUpdateRequest request)
    {
        var entity = await orderRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException($"Order {id} is not available");
        var productEntity = await productRepository.GetByIdAsync(request.ProductId);
        if (productEntity is null)
            throw new NotFoundDataException($"Product {request.ProductId} not found");
        var updateEntity = _mapper.Map(request, entity);
        updateEntity.Product = productEntity;
        await orderRepository.SaveAsync(updateEntity);
        return new ApiResponse<bool>().Success(true);
    }
}
using AutoMapper;
using FinalWebApp.Dto.Requests.Transaction;
using FinalWebApp.Dto.Responses.Transaction;
using FinalWebApp.Entities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class TransactionService: BaseService<TransactionService>, ITransactionService
{
    private ITransactionRepository _transactionRepository;
    private IUserRepository _userRepository;
    private IOrderRepository _orderRepository;
    public TransactionService(IMapper mapper, ILogger<TransactionService> logger, ITransactionRepository transactionRepository, IUserRepository userRepository, IOrderRepository orderRepository) : base(mapper, logger)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public async Task<ApiResponse<PagePagination<TransactionGetListResponse>>> GetListAsync(BaseQueryFilter filter)
    {
        var listEntity = await _transactionRepository.GetAllAsync(PageRequest.Of(filter.Page, filter.Size));
        var listResponse =
            _mapper.Map<IEnumerable<TransactionEntity>, IEnumerable<TransactionGetListResponse>>(listEntity).ToList();
        return new ApiResponse<PagePagination<TransactionGetListResponse>>().Success(
            new PagePagination<TransactionGetListResponse>
            {
                Content = listResponse,
                First = 1,
                Last = listResponse.Count(),
                TotalElements = await _transactionRepository.CountAllAsync()
            }
        );
    }

    public async Task<ApiResponse<bool>> CreateAsync(TransactionCreateRequest request)
    {
        var userEntity = await _userRepository.GetByIdAsync(request.UserId);
        if (userEntity is null)
            throw new NotFoundDataException("User is not available");
        var listOrderEntity = await _orderRepository.GetAllByIdAsync(request.OrdersId);
        var createEntity = _mapper.Map<TransactionCreateRequest, TransactionEntity>(request);
        createEntity.User = userEntity;
        createEntity.Orders = listOrderEntity.ToList();
        await _transactionRepository.SaveAsync(createEntity);
        return new ApiResponse<bool>().Success(true);
    }

    public async Task<ApiResponse<bool>> DeleteAsync(string id)
    {
        var entity = await _transactionRepository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundDataException($"Transaction {id} not found");
        await _transactionRepository.DeleteAsync(entity);
        return new ApiResponse<bool>().Success(true);
    }
}
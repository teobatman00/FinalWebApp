using AutoMapper;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class TransactionService: BaseService<TransactionService>, ITransactionService
{
    public TransactionService(IMapper mapper, ILogger<TransactionService> logger) : base(mapper, logger)
    {
    }
}
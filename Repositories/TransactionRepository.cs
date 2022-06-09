using FinalWebApp.Context;
using FinalWebApp.Entities;
using FinalWebApp.Repositories.Interfaces;

namespace FinalWebApp.Repositories;

public class TransactionRepository: BaseRepository<TransactionRepository, TransactionEntity, string>, ITransactionRepository
{
    public TransactionRepository(ILogger<TransactionRepository> logger, ApplicationContext context) : base(logger, context)
    {
    }
}
using FinalWebApp.Dto.Requests.Transaction;
using FinalWebApp.Dto.Responses.Transaction;
using FinalWebApp.Models;
using FinalWebApp.Services.BaseInterfaces;

namespace FinalWebApp.Services.Interfaces;

public interface ITransactionService: IGetListService<TransactionGetListResponse, BaseQueryFilter>,
    ICreateService<TransactionCreateRequest, bool>,
    IDeleteService<string, bool>
{
    
}
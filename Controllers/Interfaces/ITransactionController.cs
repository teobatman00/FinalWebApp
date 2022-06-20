using FinalWebApp.Controllers.BaseInterfaces;
using FinalWebApp.Dto.Requests.Transaction;
using FinalWebApp.Dto.Responses.Transaction;
using FinalWebApp.Models;

namespace FinalWebApp.Controllers.Interfaces;

public interface ITransactionController: IGetListController<TransactionGetListResponse, BaseQueryFilter>,
    ICreateController<TransactionCreateRequest, bool>,
    IDeleteController<string, bool>
{
    
}
using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Transaction;
using FinalWebApp.Dto.Responses.Transaction;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController: ControllerBase, ITransactionController
{

    private ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<PagePagination<TransactionGetListResponse>>>> GetListAsync(BaseQueryFilter filter)
    {
        var result = await _transactionService.GetListAsync(filter);
        return Ok(result);
    }

    [HttpPost(""), ValidatedModel]
    public async Task<ActionResult<ApiResponse<bool>>> CreateAsync(TransactionCreateRequest request)
    {
        var result = await _transactionService.CreateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(string id)
    {
        var result = await _transactionService.DeleteAsync(id);
        return Ok(result);
    }
}
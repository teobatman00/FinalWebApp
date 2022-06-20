using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApp.Dto.Requests.Transaction;

public record TransactionCreateRequest
{
    [Required]
    public string UserFullName { get; set; }
    public string UserEmail { get; set; }
    [Required]
    public string UserPhone { get; set; }
    [Required, Precision(2)]
    public decimal PaymentAmount { get; set; }
    public string Message { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public List<string> OrdersId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace FinalWebApp.Dto.Requests.Order;

public record OrderCreateRequest
{
    [Required]
    public string ProductId { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public decimal TotalAmount { get; set; }
}
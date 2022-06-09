namespace FinalWebApp.Dto.Responses.Order;

public record OrderGetListResponse
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}
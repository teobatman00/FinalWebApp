namespace FinalWebApp.Dto.Responses.Order;

public record Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Slugs { get; set; }
    public int Discount { get; set; }
}

public record OrderGetDetailResponse
{
    public string Id { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public Product Product { get; set; }
}
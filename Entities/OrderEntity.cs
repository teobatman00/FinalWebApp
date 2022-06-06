namespace FinalWebApp.Entities;

public class OrderEntity: BaseEntity<string>
{
    public ProductEntity Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}
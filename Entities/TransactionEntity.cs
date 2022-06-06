namespace FinalWebApp.Entities;

public class TransactionEntity: BaseEntity<string>
{
    public UserEntity User { get; set; }
    public string UserFullName { get; set; }
    public string UserEmail { get; set; }
    public string UserPhone { get; set; }
    public decimal PaymentAmount { get; set; }
    public string Message { get; set; }
    public List<OrderEntity> Orders { get; set; }
}
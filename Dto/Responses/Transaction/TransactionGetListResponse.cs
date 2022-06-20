namespace FinalWebApp.Dto.Responses.Transaction;

public record TransactionGetListResponse
{
    public string Id { get; set; }
    public string UserFullName { get; set; }
    public string UserPhone { get; set; }
    public string PaymentAmount { get; set; }
}
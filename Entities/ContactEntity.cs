namespace FinalWebApp.Entities;

public class ContactEntity: BaseEntity<string>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    
}
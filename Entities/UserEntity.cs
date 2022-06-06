namespace FinalWebApp.Entities;

public class UserEntity: BaseEntity<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRoleEntity Role { get; set; }
    public List<TransactionEntity> Transactions { get; set; }
}
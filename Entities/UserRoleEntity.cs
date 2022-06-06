namespace FinalWebApp.Entities;

public class UserRoleEntity: BaseEntity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
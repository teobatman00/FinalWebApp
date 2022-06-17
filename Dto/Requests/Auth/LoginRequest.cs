using System.ComponentModel.DataAnnotations;

namespace FinalWebApp.Dto.Requests.Auth;

public record LoginRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
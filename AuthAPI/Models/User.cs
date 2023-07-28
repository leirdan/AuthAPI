using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models;

public class User : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime Birthday { get; set; }
    public User() : base() { }
} 
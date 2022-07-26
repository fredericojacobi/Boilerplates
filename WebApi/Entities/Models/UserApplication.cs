using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class UserApplication : IdentityUser<int>
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
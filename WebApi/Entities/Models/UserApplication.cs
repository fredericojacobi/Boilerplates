using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class UserApplication : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
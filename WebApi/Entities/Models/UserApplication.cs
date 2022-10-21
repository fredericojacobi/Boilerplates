using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class UserApplication : IdentityUser<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SecondaryId { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }
    
    public UserType UserType { get; set; }
    
    public DateTime? PaidUntil { get; set; }
    
    [NotMapped]
    public bool IsAdmin { get; set; }
    
    [NotMapped]
    public bool IsFreeUser { get; set; }
}
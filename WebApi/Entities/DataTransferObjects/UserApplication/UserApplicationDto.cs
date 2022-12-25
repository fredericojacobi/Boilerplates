using Entities.Enums;
using Generics.Models;

namespace Entities.DataTransferObjects.UserApplication;

public class UserApplicationDto : BaseModelDto
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public UserType UserType { get; set; }
    
    public string? PaidUntil { get; set; }
    
    public bool IsAdmin => UserType.Equals(UserType.Admin);

    public bool IsFreeUser => UserType.Equals(UserType.Free) || UserType.Equals(UserType.Undefined);
}
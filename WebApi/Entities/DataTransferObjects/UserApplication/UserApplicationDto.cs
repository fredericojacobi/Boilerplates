using Generics.Models;

namespace Entities.DataTransferObjects.UserApplication;

public class UserApplicationDto : BaseModelDto
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
}
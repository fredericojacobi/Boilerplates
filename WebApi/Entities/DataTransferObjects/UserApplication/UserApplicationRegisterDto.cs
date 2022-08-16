using Generics.Models;

namespace Entities.DataTransferObjects.UserApplication;

public class UserApplicationRegisterDto : BaseModelDto
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
}
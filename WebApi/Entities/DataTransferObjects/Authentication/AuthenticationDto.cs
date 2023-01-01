namespace Entities.DataTransferObjects.Authentication;

public class AuthenticationDto
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string Token { get; set; }
}
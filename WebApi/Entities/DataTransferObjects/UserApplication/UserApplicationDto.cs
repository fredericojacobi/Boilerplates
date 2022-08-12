namespace Entities.DataTransferObjects.UserApplication;

public class UserApplicationDto
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
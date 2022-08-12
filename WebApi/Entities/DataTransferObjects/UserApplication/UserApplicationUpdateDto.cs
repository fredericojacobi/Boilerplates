namespace Entities.DataTransferObjects.UserApplication;

public class UserApplicationUpdateDto
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
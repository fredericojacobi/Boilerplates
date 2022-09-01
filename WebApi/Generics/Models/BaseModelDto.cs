namespace Generics.Models;

public abstract class BaseModelDto
{
    public Guid? Id { get; set; }
    
    public string? CreatedAt { get; set; }
    
    public string? ModifiedAt { get; set; }
}
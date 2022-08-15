using System.ComponentModel.DataAnnotations;

namespace Generics.Models;

public abstract class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime ModifiedAt { get; set; }
}
using Entities.Enums;
using Generics.Models;

namespace Entities.Models;

public class Log : BaseModel
{
    public LogType LogType { get; set; } = LogType.Undefined;
    
    public string Path { get; set; }
    
    public string Method { get; set; }
    
    public string Message { get; set; }

    public Guid? UserApplicationId { get; set; }
    
    public UserApplication? UserApplication { get; set; }
}

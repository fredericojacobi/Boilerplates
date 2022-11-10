using System.Text;
using Entities.Enums;
using Generics.Models;

namespace Entities.Models;

public class Log : BaseModel
{
    public LogType LogType { get; set; } = LogType.Undefined;

    public string Path { get; set; }

    public string Method { get; set; }

    public string Message { get; set; }

    public string? FileDetailsPath { get; set; }

    public Guid? UserApplicationId { get; set; }

    public UserApplication? UserApplication { get; set; }

    public void CreateFileDetails(string dirPath, string fileName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($@"{CreatedAt.ToString("dd/MM/yyyy HH:mm:ss.fff")} - [{LogType}]: {Message} UserId: {UserApplicationId}. {Path} - {Method}");
        var filePath = System.IO.Path.Combine(dirPath, $"{fileName}.txt");
        File.AppendAllText(filePath, stringBuilder.ToString());
    }
}
using System.Text;
using Entities.Enums;
using Extensions;
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

    public void CreateFileDetails(string dirPath)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(
            $@"{CreatedAt.ToString("dd/MM/yyyy HH:mm:ss.fff")} - [{LogType}]: {Message} UserId: {UserApplicationId}. {Path} - {Method} method");

        var dirInfo = new DirectoryInfo(dirPath);
        // set new file path if not exist or >= 5mb
        var filePath = System.IO.Path.Combine(dirInfo.FullName, $"logfile_{Guid.NewGuid().ToShortGuid()}.txt");

        // find last written logfile
        var currentFile = dirInfo.EnumerateFiles().OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
        if (currentFile != null)
        {
            var fileStream = File.OpenRead(currentFile.FullName);
            var filesizeLimitExceeded = fileStream.ToMegabytes() >= 5;
            fileStream.Close();
            // create new logfile if file size >= 5mb
            if(!filesizeLimitExceeded)
                filePath = currentFile.FullName;
        }

        // write log content
        File.AppendAllText(filePath, stringBuilder.ToString());
    }
}
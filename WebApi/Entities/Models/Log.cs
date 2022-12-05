using System.Text;
using Entities.Enums;
using Generics.Extensions;
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
            $@"{CreatedAt.ToStringLogFormat(DateTime.Now)} - [{LogType}]: {Message} UserId: {UserApplicationId}. {Path} - {Method} method");

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
            
            // append current log to the end of file
            var currentContent = File.ReadAllText(currentFile.FullName);
            stringBuilder.AppendLine(currentContent);
            
            // create new logfile if file size >= 5mb
            if(!filesizeLimitExceeded)
                filePath = currentFile.FullName;
        }

        // write log content to the beginning of file
        
        File.WriteAllText(filePath, stringBuilder.ToString());
    }
}
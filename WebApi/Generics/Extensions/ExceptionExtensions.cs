namespace Generics.Extensions;

public static class ExceptionExtensions
{
    public static string FormatLogMessage(this Exception exception) => $"{DateTime.Now} : {exception.Message} \n Source: {exception.Source} \n InnerException: {exception.InnerException}";
}
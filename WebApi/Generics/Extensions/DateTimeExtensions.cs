namespace Generics.Extensions;

public static class DateTimeExtensions
{
    public static bool IsDefault(this DateTime dateTime) => dateTime.Equals(DateTime.MinValue);

    public static string ToStringLogFormat(this DateTime dateTime) => dateTime.ToString(Constants.DateTime.LOGFORMAT);

    public static string ToStringLogFormat(this DateTime dateTime, DateTime defaultValue) =>
        dateTime.IsDefault()
            ? defaultValue.ToString(Constants.DateTime.LOGFORMAT)
            : dateTime.ToString(Constants.DateTime.LOGFORMAT);
}
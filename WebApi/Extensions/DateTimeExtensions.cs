namespace Extensions;

public static class DateTimeExtensions
{
    public static bool IsDefault(this DateTime dateTime) => dateTime.Equals(DateTime.MinValue);
}
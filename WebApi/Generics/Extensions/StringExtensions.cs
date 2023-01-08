namespace Generics.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string? str) => string.IsNullOrWhiteSpace(str);
    
    public static Guid ToGuid(this string? str) => str.IsNullOrWhiteSpace() ? Guid.Empty : Guid.Parse(str);
}
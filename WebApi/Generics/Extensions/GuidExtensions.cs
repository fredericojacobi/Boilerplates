namespace Generics.Extensions;

public static class GuidExtensions
{
    public static bool IsNotDefault(this Guid guid) => !guid.Equals(Guid.Empty);
    
    public static bool IsDefault(this Guid guid) => guid.Equals(Guid.Empty);

    public static string ToShortGuid(this Guid guid) => guid.ToString("N")[..6];
}
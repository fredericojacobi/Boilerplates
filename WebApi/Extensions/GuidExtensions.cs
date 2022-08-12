namespace Extensions;

public static class GuidExtensions
{
    public static bool IsNotDefault(this Guid guid) => !guid.Equals(Guid.Empty);
    
    public static bool IsDefault(this Guid guid) => guid.Equals(Guid.Empty);
}
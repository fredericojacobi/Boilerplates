namespace Extensions;

public static class StreamExtensions
{
    public static float ToMegabytes(this Stream stream) => (stream.Length / 1024f) / 1024f;
}
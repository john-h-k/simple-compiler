using System.IO;


internal static class TextReaderExtensions
{
    public static char ReadChar(this TextReader reader)
        => (char)reader.Read();

    public static char PeekChar(this TextReader reader)
        => (char)reader.Peek();
}
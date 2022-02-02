using System;

internal partial class Parser
{
    private TextReader? _text;

    public ParseResult Parse(string text)
    {
        throw null!;
    }

    internal bool IntegerLiteral() {
        

        while (Char.IsNumber(_text.PeekChar())) {

        }
    }

    // Whitespace
    internal bool Trivia()
    {
        int count = 0;

        while (Char.IsWhiteSpace(_text.PeekChar()))
        {
            _text.ReadChar();
            count++;
        }

        return count == 0;
    }
}
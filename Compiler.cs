using System;

public class Compiler
{
    private FileInfo[] _input;
    private FileInfo? _output;
    private Verbosity _verbosity;

    private bool Verbose(Verbosity verbosity)
    {
        return verbosity <= _verbosity;
    }

    public Compiler(FileInfo[] input, FileInfo output, Verbosity verbosity)
    {
        _input = input;
        _output = output;
        _verbosity = verbosity;

        Console.WriteLine(verbosity);

        if (Verbose(Verbosity.Debug))
        {
            Console.WriteLine($"Input files: {string.Join(", ", _input.Select(f => f.Name))}");
            Console.WriteLine($"Verbosity: {_verbosity}");
        }
    }
}
using System;
using System.CommandLine;
using System.CommandLine.Invocation;

public enum Verbosity
{
    Silent = 0,
    Quiet = 1,
    Default = 2,
    Verbose = 3,
    Debug = 4
}

public class Program
{
    private static string[] WithAlias(string name, char? simpleName = null)
    {
        string alias;

        if (simpleName is null)
        {
            alias = $"-{simpleName.ToString()}";
        }
        else
        {
            alias = simpleName.ToString()!;
        }

        return new[] { name, alias };
    }

    public static int Main(string[] args)
    {
        var output = new Option<FileInfo>(
            WithAlias("--output-file"),
            "The file to write the output program to"
        );

        var verbosity = new Option<Verbosity>(
            WithAlias("--verbosity"),
            () => Verbosity.Default,
            "The verbosity level to use during compilation"
        );

        var input = new Argument<FileInfo[]>("Files", "The files to compile");

        var command = new RootCommand {
            input,
            output,
            verbosity
        };

        command.SetHandler((InvocationContext context, FileInfo[] input, FileInfo output, Verbosity verbosity) =>
        {
            var compiler = new Compiler(input, output, verbosity);

            context.ExitCode = 0;
        }, input, output, verbosity);

        return command.Invoke(args);
    }
}
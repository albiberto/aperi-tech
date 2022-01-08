// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Domain;
using Microsoft.Extensions.Options;
using Options;

public class Printer : IPrinter
{
    private readonly AppOptions _options;

    public Printer(IOptions<AppOptions> options)
    {
        _options = options.Value;
    }

    public void Print(IEnumerable<Shape> shapes)
    {
        // local functions: C# 7.0
        // static local functions: C# 8.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
        static void LocalPrint(string message)
        {
            Console.Write("    ");
            Console.Write($"MESSAGE: {message}");
            Console.WriteLine();
        }

        foreach (var shape in shapes)
        {
            shape.WriteToConsole("Printer", false);
            LocalPrint(GetMessage(shape));

            Console.WriteLine();

            Thread.Sleep(_options.Settings.Delay);
        }
    }

    private static string GetMessage(Shape shape)
    {
        string message;

        switch (shape.Angles)
        {
            // string interpolation: C# 6.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            case 0:
                message = string.Equals(shape.Color, "Red", StringComparison.OrdinalIgnoreCase)
                    ? $"ID={shape.Id} CIRCLE is red"
                    // nullable reference types (!): C# 8.0
                    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types
                    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-warnings#possible-dereference-of-null
                    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-variable-annotations 
                    : $"ID={shape.Id} CIRCLE is {shape.Color!.ToUpperInvariant()}";
                break;
            case 4:
                message = string.Equals(shape.Color, "REd", StringComparison.OrdinalIgnoreCase)
                    ? $"ID={shape.Id} SQUARE is red"
                    : $"ID={shape.Id} SQUARE is {shape.Color!.ToUpperInvariant()}";
                break;
            default:
                // nameof operator: C# 6.0
                // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof
                throw new ArgumentOutOfRangeException(nameof(shape));
        }

        return message;
    }
}
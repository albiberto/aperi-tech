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
            LocalPrint(AnotherPatternMatching(shape));

            Console.WriteLine();

            Thread.Sleep(_options.Settings.Delay);
        }
    }

    private static string GetMessage(Shape shape)
    {
        // Pattern matching: C# 8.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#more-patterns-in-more-places
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#property-patterns
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#positional-patterns 
        // Pattern matching enhancement: C# 9.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#declaration-and-type-patterns
        return shape switch
        {
            // string interpolation: C# 6.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            Circle when string.Equals(shape.Color, "Red", StringComparison.OrdinalIgnoreCase) => $"ID={shape.Id} CIRCLE is red",
            Circle (var id, var color) => $"ID={id} CIRCLE is {color!.ToUpperInvariant()}",
            Square(var id, "red") => $"ID={id} SQUARE is red",
            { } => $"ID={shape.Id} SQUARE is {shape.Color.ToUpperInvariant()}",
            _ => throw new ArgumentOutOfRangeException(nameof(shape))
        };
    }

    private static string AnotherPatternMatching(Shape shape)
    {
        //pattern matching: C# 7.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
        // is operator: C# 7.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-70
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/is
        if (shape is Circle(var id, var color)) return $"ID={id} CIRCLE is {color!.ToLowerInvariant()}";

        // as operator: C# 7.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-70
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
        // nullable reference types (!): C# 8.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-warnings#possible-dereference-of-null
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-variable-annotations 
        var square = shape as Square;
        return $"ID={square!.Id} SQUARE is {square.Color.ToLowerInvariant()}";
    }
}
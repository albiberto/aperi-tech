// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Domain;
using Microsoft.Extensions.Options;
using Options;

public class Checker : IChecker
{
    private readonly AppOptions _options;

    // omit the type in a new expression: C# 9.0
    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#fit-and-finish-features
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator
    private readonly List<IShape> _validShapes = new();

    public Checker(IOptions<AppOptions> options)
    {
        _options = options.Value;

        // language integrated query (LINQ): C# 3.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        var circles =
            from id in Enumerable.Range(0, _options.Settings.Total)
            from color in _options.Shapes.Colors
            select new Circle(id, color);

        var squares =
            from id in Enumerable.Range(0, _options.Settings.Total)
            from color in _options.Shapes.Colors
            select new Square(id, color);

        _validShapes.AddRange(circles);
        _validShapes.AddRange(squares);
    }

    public IEnumerable<IShape> Check(IEnumerable<IShape> shapes)
    {
        foreach (var shape in shapes)
        foreach (var validShape in _validShapes)
        {
            // equality comparison: C# 1.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons
            // equality operators: C# 1.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
            if (!validShape.Equals(shape) && validShape != shape) continue;

            shape.WriteToConsole("Checker");

            // iterators: C# 2.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
            yield return shape;
            Thread.Sleep((_options.Settings.Delay));
            break;
        }
    }
}
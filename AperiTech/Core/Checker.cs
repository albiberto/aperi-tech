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

    private readonly IEnumerable<Shape> _validShapes;

    public Checker(IOptions<AppOptions> options)
    {
        _options = options.Value;

        // language integrated query (LINQ): C# 3.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        _validShapes =
            from id in Enumerable.Range(0, _options.Settings.Total)
            from count in _options.Shapes.Angles
            from color in _options.Shapes.Colors
            select new Shape(id, count, color);
    }

    public IEnumerable<Shape> Check(IEnumerable<Shape> shapes)
    {
        var acc = new List<Shape>();

        foreach (var shape in shapes)
        foreach (var validShape in _validShapes)
        {
            // equality comparison: C# 1.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons
            // equality operators: C# 1.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
            if (!validShape.Equals(shape) && validShape != shape) continue;

            shape.WriteToConsole("Checker");
            acc.Add(shape);
            Thread.Sleep((_options.Settings.Delay));
            break;
        }

        return acc;
    }
}
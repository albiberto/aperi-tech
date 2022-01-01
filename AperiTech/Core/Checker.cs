// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Domain;

public class Checker : IChecker
{
    // auto-property initializers: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/properties#property-syntax
    private static IEnumerable<int> Angles { get; } = new HashSet<int> {0, 4};

    // expression-bodied members: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/properties#property-syntax
    private static IEnumerable<string> Colors => new HashSet<string> {"red", "blue", "yellow"};

    private readonly IEnumerable<Shape> _validShapes;

    public Checker()
    {
        // language integrated query (LINQ): C# 3.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        _validShapes =
            from id in Enumerable.Range(0, Settings.Total)
            from count in Angles
            from color in Colors
            // object and collection initializers: C# 3.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            select new Shape
            {
                Id = id,
                Angles = count,
                Color = color
            };
    }

    public IEnumerable<Shape> Check(IEnumerable<Shape> shapes)
    {
        var acc = new List<Shape>();

        foreach (var shape in shapes)
        foreach (var validShape in _validShapes)
        {
            if (validShape.Id != shape.Id || validShape.Angles != shape.Angles || validShape.Color != shape.Color) continue;

            shape.WriteToConsole("Checker");
            acc.Add(shape);
            Thread.Sleep(Settings.Delay);
            break;
        }

        return acc;
    }
}
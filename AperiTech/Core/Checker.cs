// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Domain;
using Microsoft.Extensions.Configuration;

public class Checker : IChecker
{
    private readonly int _delay;

    private readonly IEnumerable<Shape> _validShapes;

    public Checker(IConfiguration configuration)
    {
        _delay = configuration.GetValue<int>("AppSettings:Delay");
        var total = configuration.GetValue<int>("AppSettings:Total");

        var angles = new[] {configuration.GetValue<int>("AppOptions:Angles:0"), configuration.GetValue<int>("AppOptions:Angles:1")};
        var colors = new[] {configuration["AppOptions:Colors:0"], configuration["AppOptions:Colors:1"], configuration["AppOptions:Colors:2"]};

        // language integrated query (LINQ): C# 3.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        _validShapes =
            from id in Enumerable.Range(0, total)
            from count in angles
            from color in colors
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
            Thread.Sleep(_delay);
            break;
        }

        return acc;
    }
}
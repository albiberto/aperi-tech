// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Bogus;
using Domain;

public class Provider : IProvider
{
    // auto-property initializers: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/properties#property-syntax
    private static IEnumerable<int> Angles { get; } = new HashSet<int> {0, 4};

    // omit the type in a new expression: C# 9.0
    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#fit-and-finish-features
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator
    private readonly Faker _faker = new();

    public IEnumerable<Shape> Get()
    {
        var acc = new List<Shape>();

        foreach (var index in Enumerable.Range(0, Settings.Total))
        {
            // object and collection initializers: C# 3.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            var shape = new Shape
            {
                Id = index,
                Angles = _faker.PickRandom(Angles)
            };

            shape.WriteToConsole("Provider");
            acc.Add(shape);
            Thread.Sleep(Settings.Delay);
        }

        return acc;
    }
}
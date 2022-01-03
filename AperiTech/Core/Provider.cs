// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Core;

using Abstract;
using Bogus;
using Domain;
using Microsoft.Extensions.Options;
using Options;

public class Provider : IProvider
{
    private readonly Faker _faker;
    private readonly AppOptions _options;

    public Provider(Faker faker, IOptions<AppOptions> options)
    {
        _faker = faker;
        _options = options.Value;
    }

    public IEnumerable<Shape> Get()
    {
        var acc = new List<Shape>();

        foreach (var index in Enumerable.Range(0, _options.Settings.Total))
        {
            // object and collection initializers: C# 3.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            var shape = new Shape
            {
                Id = index,
                Angles = _faker.PickRandom(_options.Shapes.Angles)
            };

            shape.WriteToConsole("Provider");
            acc.Add(shape);
            Thread.Sleep(_options.Settings.Delay);
        }

        return acc;
    }
}
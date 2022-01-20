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

public class Painter : IPainter
{
    private readonly Faker _faker;
    private readonly AppOptions _options;

    public Painter(Faker faker, IOptions<AppOptions> options)
    {
        _faker = faker;
        _options = options.Value;
    }

    // asynchronous streams: C# 8.0
    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-streams
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/generate-consume-asynchronous-stream
    public async IAsyncEnumerable<IShape> PaintAsync(IAsyncEnumerable<IShape> shapes)
    {
        // using declaration: C# 8.0
        // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
        await using var enumerator = shapes.GetAsyncEnumerator();
        while (await enumerator.MoveNextAsync())
        {
            var current = enumerator.Current as Shape;
            // with expression: C# 9.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression
            // nullable reference types (!): C# 8.0
            // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-warnings#possible-dereference-of-null
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-variable-annotations 
            IShape shape = current! with {Color = _faker.PickRandom(_options.Shapes.Colors).OrNull(_faker, 0.2f)};

            shape.WriteToConsole("Painter");

            // iterators: C# 2.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
            yield return shape;
            await Task.Delay(_options.Settings.Delay);
        }
    }
}
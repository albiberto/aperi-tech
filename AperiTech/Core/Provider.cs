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

    public async Task<IEnumerable<IShape>> GetAsync()
    {
        foreach (var index in Enumerable.Range(0, _options.Settings.Total))
        {
            IShape shape = _faker.Random.Bool()
                ? new Circle(index)
                : new Square(index);

            shape.WriteToConsole("Provider");

            // iterators: C# 2.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
            yield return shape;
            await Task.Delay(_options.Settings.Delay);
        }
    }
}
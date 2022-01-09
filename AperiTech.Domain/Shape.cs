// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Domain;

public class Shape
{
    // Nullable reference types (?): C# 8.0
    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/nullable-reference-types
    // default literal expressions: C# 7.1
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default#default-literal
    public Shape(int id, int angles, string? color = default)
    {
        Id = id;
        Angles = angles;
        Color = color ?? string.Empty;
    }

    public int Id { get; }
    public int Angles { get; }
    public string Color { get; }

    // expression-bodied members: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
    // string interpolation: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
    // ?: operator: C# 1.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
    public override string ToString() => $"SHAPE: ID={Id} Angles={Angles} Color={(string.IsNullOrEmpty(Color) ? "N/A" : Color.ToUpperInvariant())}";
}
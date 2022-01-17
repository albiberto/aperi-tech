// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Domain;

// Nullable reference types (?): C# 8.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/nullable-reference-types
// default literal expressions: C# 7.1
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default#default-literal
public abstract record Shape(int Id, string? Color = default) : IShape
{
    // init only setters: C# 9.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters
    public string Color { get; init; } = Color ?? string.Empty;
}

public record Circle(int Id, string? Color = default) : Shape(Id, Color), ICircle;

public record Square(int Id, string? Color = default) : Shape(Id, Color), ISquare;
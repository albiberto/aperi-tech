// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech.Domain;

public class Shape : IEquatable<Shape>
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

    // Tuples and deconstruction: C# 7.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-assignment-and-deconstruction
    public void Deconstruct(out int id, out int angles, out string color)
    {
        id = Id;
        angles = Angles;
        color = Color;
    }

    public bool Equals(Shape? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Angles == other.Angles && string.Equals(Color, other.Color, StringComparison.InvariantCultureIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Shape) obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(Angles);
        hashCode.Add(Color, StringComparer.InvariantCultureIgnoreCase);
        return hashCode.ToHashCode();
    }

    // operator overloading: C# 1.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
    // equality operators: C# 1.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
    public static bool operator ==(Shape? left, Shape? right) => Equals(left, right);
    public static bool operator !=(Shape? left, Shape? right) => !Equals(left, right);

    // expression-bodied members: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
    // string interpolation: C# 6.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
    // ?: operator: C# 1.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
    public override string ToString() => $"SHAPE: ID={Id} Angles={Angles} Color={(string.IsNullOrEmpty(Color) ? "N/A" : Color.ToUpperInvariant())}";
}
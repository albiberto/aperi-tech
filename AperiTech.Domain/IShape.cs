namespace AperiTech.Domain;

// default interface methods: C# 8.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#default-interface-methods
// DOC (old): https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods
public interface IShape
{
    public int Id { get; }
    public string Color { get; }

    // interface properties: C# 8.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/interface-properties
    virtual string Message => $"ID={Id} SHAPE is {Color.ToLowerInvariant()}";

    // virtual extension methods: C# 8.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods
    public void WriteToConsole(string step, bool newLine = true)
    {
        // string interpolation: C# 6.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        // format specifier: C# 7.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation#how-to-specify-a-format-string-for-an-interpolation-expression
        Console.WriteLine("{0}_{1} run at {2:O}", step, Id, DateTime.Now);
        Console.Write("    ");
        Console.Write(this);
        Console.WriteLine();

        if (newLine) Console.WriteLine();
    }
}

public interface ICircle : IShape
{
}

public interface ISquare : IShape
{
    string IShape.Message => $"ID={Id} SQUARE is {Color.ToLowerInvariant()}";
}
// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech;

using Domain;

public static class Helpers
{
    // extension methods: C# 3.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    // DOC: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/extension-methods
    public static void WriteToConsole(this Shape shape, string step, bool newLine = true)
    {
        // string interpolation: C# 6.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        // format specifier: C# 7.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation#how-to-specify-a-format-string-for-an-interpolation-expression
        Console.WriteLine("{0}_{1} run at {2:O}", step, shape.Id, DateTime.Now);
        Console.Write("    ");
        Console.Write(shape);
        Console.WriteLine();

        if (newLine) Console.WriteLine();
    }
}
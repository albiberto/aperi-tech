namespace AperiTech.Options;

using System.ComponentModel.DataAnnotations;

public class AppOptions
{
    // nullable reference types (null!): C# 8.0
    // NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-warnings#nonnullable-reference-not-initialized
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-variable-annotations 
    public ShapeOption Shapes { get; set; } = null!;
    public Settings Settings { get; set; } = null!;
}

public class ShapeOption
{
    [Required] [MinLength(3)] public IEnumerable<string> Colors { get; set; } = null!;
}

public class Settings
{
    [Range(100, 2000, ErrorMessage = "Delay must be between 100 and 2000")]
    public int Delay { get; set; }

    [Range(10, 20, ErrorMessage = "Total must be between 10 and 20")]
    public int Total { get; set; }
}
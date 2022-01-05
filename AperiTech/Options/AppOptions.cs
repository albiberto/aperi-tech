namespace AperiTech.Options;

using System.ComponentModel.DataAnnotations;

public class AppOptions
{
    public ShapeOption Shapes { get; set; }
    public Settings Settings { get; set; }
}

public class ShapeOption
{
    [Required] [MinLength(3)] public IEnumerable<string> Colors { get; set; }
    [Required] [MinLength(2)] public IEnumerable<int> Angles { get; set; }
}

public class Settings
{
    [Range(100, 2000, ErrorMessage = "Delay must be between 100 and 2000")]
    public int Delay { get; set; }

    [Range(10, 20, ErrorMessage = "Total must be between 10 and 20")]
    public int Total { get; set; }
}
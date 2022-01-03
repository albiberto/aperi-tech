namespace AperiTech.Options;

public class AppOptions
{
    public ShapeOption Shapes { get; set; }
    public Settings Settings { get; set; }
}

public class ShapeOption
{
    public IEnumerable<int> Angles { get; set; }
    public IEnumerable<string> Colors { get; set; }
}

public class Settings
{
    public int Total { get; set; }
    public int Delay { get; set; }
}
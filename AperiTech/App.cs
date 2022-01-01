// file-scoped namespaces: C# 10.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#file-scoped-namespace-declaration
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
// DOC: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/#file-scoped-namespaces

namespace AperiTech;

using Abstract;

public class App
{
    private const string Provider = "Provider";
    private const string Painter = "Painter";
    private const string Checker = "Checker";
    private const string Printer = "Printer";

    private readonly IProvider _provider;
    private readonly IPainter _painter;
    private readonly IChecker _checker;
    private readonly IPrinter _printer;

    public App(IProvider provider, IPainter painter, IChecker checker, IPrinter printer)
    {
        _provider = provider;
        _painter = painter;
        _checker = checker;
        _printer = printer;
    }

    public void Run()
    {
        CountDown(Provider);
        var shapes = _provider.Get();
        Complete(Provider);

        CountDown(Painter);
        _painter.Paint(shapes);
        Complete(Painter);

        CountDown(Checker);
        var valid = _checker.Check(shapes);
        Complete(Checker);

        CountDown(Printer);
        _printer.Print(valid);
        Complete(Printer);
    }

    private static void CountDown(string message)
    {
        Console.WriteLine();
        Console.Write("{0} launching ", message);

        foreach (var _ in Enumerable.Range(0, 3))
        {
            Console.Write(".");
            Thread.Sleep(Settings.Delay);
        }

        Console.WriteLine();
        // string interpolation: C# 6.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        // format specifier: C# 7.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation#how-to-specify-a-format-string-for-an-interpolation-expression
        Console.WriteLine("{0} launched at: {1:O}", message, DateTime.Now);
        Console.WriteLine();
    }

    private static void Complete(string message)
    {
        Console.WriteLine();
        // string interpolation: C# 6.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        // format specifier: C# 7.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation#how-to-specify-a-format-string-for-an-interpolation-expression
        Console.WriteLine("{0} completed at: {1:O}", message, DateTime.Now);
        Console.WriteLine();

        Thread.Sleep(Settings.Delay * 2);
    }
}
// top level templates: C# 9.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates#use-the-new-program-style

using AperiTech;
using AperiTech.Core;

// static imports: C# 6.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
using static AperiTech.Settings;

// implicitly typed local variables (var): C# 3.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
var provider = new Provider();
var painter = new Painter();
var checker = new Checker();
var printer = new Printer();

var app = new App(provider, painter, checker, printer);

Welcome();
app.Run();
Wait();
SeeYouSoon();

static void Welcome()
{
    Console.WriteLine("Welcome to AperiTech");
    Console.WriteLine("Renew your .NET");

    Thread.Sleep(GetDelay() * 4);
    Console.Clear();
    Thread.Sleep(GetDelay() * 2);
}

static void Wait()
{
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    Console.Clear();
    Thread.Sleep(GetDelay());
}

static void SeeYouSoon()
{
    Console.WriteLine("See you soon!");
    Console.WriteLine();

    Console.WriteLine("<3 <3 <3 <3 <3");
    Console.WriteLine(" Gruppo Euris ");
    Console.WriteLine("<3 <3 <3 <3 <3");

    Thread.Sleep(GetDelay() * 8);
    Console.Clear();
}

static int GetDelay()
{
    return Delay;
}
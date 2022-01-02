// top level templates: C# 9.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates#use-the-new-program-style

using AperiTech;
using AperiTech.Abstract;
using AperiTech.Core;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// static imports: C# 6.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
using static AperiTech.Settings;

// dependency injection: dotnet Core 1.x
// DOC: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection?view=aspnetcore-6.0
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
// default host builder, web application builder: .NET 6
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-6.0
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0
using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IProvider, Provider>();
        services.AddSingleton<IPainter, Painter>();
        services.AddSingleton<IChecker, Checker>();
        services.AddSingleton<IPrinter, Printer>();

        services.AddScoped<Faker>();

        services.AddTransient<App>();
    })
    .Build();

// implicitly typed local variables (var): C# 3.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
// resolve a service at app start up: dotnet Core 1.x
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0#resolve-a-service-at-app-start-up
var app = host.Services.GetRequiredService<App>();

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

// expression-bodied members: C# 6.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
static int GetDelay() => Delay;
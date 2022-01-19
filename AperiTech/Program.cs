// top level templates: C# 9.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
// DOC: https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates#use-the-new-program-style

using AperiTech;
using AperiTech.IoC;
using AperiTech.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

// dependency injection: dotnet Core 1.x
// DOC: https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection?view=aspnetcore-6.0
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
// default host builder, web application builder: .NET 6
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-6.0
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0
using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddCoreServices();
        services.AddOptionsAndFakerServices();

        services.AddTransient<App>();
    })
    .Build();

// implicitly typed local variables (var): C# 3.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
// resolve a service at app start up: dotnet Core 1.x
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0#resolve-a-service-at-app-start-up
var app = host.Services.GetRequiredService<App>();
var options = host.Services.GetService<IOptions<AppOptions>>();

// asynchronous members: C# 5.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history
await WelcomeAsync();
await app.RunAsync();
await WaitAsync();
await SeeYouSoonAsync();

async Task WelcomeAsync()
{
    Console.WriteLine("Welcome to AperiTech");
    Console.WriteLine("Renew your .NET");

    await Task.Delay(GetDelay() * 4);
    Console.Clear();
    await Task.Delay(GetDelay() * 2);
}

async Task WaitAsync()
{
    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
    Console.Clear();
    await Task.Delay(GetDelay());
}

async Task SeeYouSoonAsync()
{
    Console.WriteLine("See you soon!");
    Console.WriteLine();

    Console.WriteLine("<3 <3 <3 <3 <3");
    Console.WriteLine(" Gruppo Euris ");
    Console.WriteLine("<3 <3 <3 <3 <3");

    await Task.Delay(GetDelay() * 8);
    Console.Clear();
}

// expression-bodied members: C# 6.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition// null propagator (?.): C# 6.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
// coalescing operator (??): C# 1.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
// Enhanced coalescing operator (?? throw new exception): C# 7.0
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator#examples
// null coalescing assignment (??=): C# 8.0
// NEW: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment
// DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
int GetDelay()
{
    int? delay = options?.Value?.Settings.Delay;
    delay ??= 250;
    return delay ?? throw new ArgumentException("Delay cannot be empty!");
}
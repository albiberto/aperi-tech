namespace AperiTech.IoC;

using Abstract;
using Bogus;
using Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Options;

// DI: best practice
// DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0#register-groups-of-services-with-extension-methods

public static class Startup
{
    // extension methods: C# 3.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    // DOC: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/extension-methods
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IProvider, Provider>();
        services.AddSingleton<IPainter, Painter>();
        services.AddSingleton<IChecker, Checker>();
        services.AddSingleton<IPrinter, Printer>();
    }

    // extension methods: C# 3.0
    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    // DOC: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/extension-methods
    public static void AddOptionsAndFakerServices(this IServiceCollection services)
    {
        // configuration in .NET: dotnet Core 1.x
        // DOC: https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration#basic-example
        // DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        // options pattern: dotnet Core 1.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/core/extensions/options#optionsbuilder-api
        // DOC: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0#optionsbuilder-api
        services
            .AddOptions<AppOptions>()
            .Bind(config.GetSection("AppOptions"))
            .ValidateDataAnnotations();

        services.AddScoped<Faker>();
    }
}
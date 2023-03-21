using Mapify.Brokers.Logging;
using Mapify.Services;

namespace Mapify.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureLoggers(this IServiceCollection services)
    {
        services.AddSingleton<ILoggingBroker, LoggingBroker>();
        services.AddTransient<ILogger, Logger<ILoggingBroker>>();

        return services;
    }

    public static IServiceCollection ConfigureService(this IServiceCollection services) => services.AddScoped<IMapifyService, MapifyService>();
}
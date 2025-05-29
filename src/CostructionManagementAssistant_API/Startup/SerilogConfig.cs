using Serilog;

namespace ConstructionManagementAssistant.API.Startup;

public static class SerilogConfig
{
    public static void UseSerilogLoggging(this IHostBuilder host)
    {
        host.UseSerilog((context, services, configuration) =>
        configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
    }
}

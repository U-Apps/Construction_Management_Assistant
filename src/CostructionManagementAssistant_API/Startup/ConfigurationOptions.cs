namespace ConstructionManagementAssistant.API.Startup;

public static class ConfigurationOptions
{
    public static void AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWT>(configuration.GetSection("JWT"));
        services.Configure<OpenAIOptions>(configuration.GetSection("OpenAI"));
    }
}

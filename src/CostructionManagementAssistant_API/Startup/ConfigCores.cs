namespace ConstructionManagementAssistant.API.Startup;

public static class ConfigCores
{
    public static void AddCores(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.WithOrigins("https://construction-management-app.vercel.app")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
    }
}

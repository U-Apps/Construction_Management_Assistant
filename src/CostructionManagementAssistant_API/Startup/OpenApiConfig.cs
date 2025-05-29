using Scalar.AspNetCore;

namespace ConstructionManagementAssistant.API.Startup;

public static class OpenApiConfig
{

    public static void AddOpenApiServices(this IServiceCollection services)
    {
        services.AddOpenApi();
    }

    public static void UseOpenApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.Title = "her heading from scalar";
                options.Theme = ScalarTheme.Saturn;
                options.Layout = ScalarLayout.Modern;
                options.HideClientButton = true;
            });
        }
    }
}

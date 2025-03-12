using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ConstructionManagementAssistant_API.Startup;

public static class SwaggerConfig
{
    public static List<string> programmerNames = new List<string> { "Saleh Mohammed", "Yousef Abdollah", "Faroug Ali", "Ahemd Raid", "Faisal Omer", "Yamani Jamal", "Mohammad Saleh" };

    public static void AddSwaggerServices(this IServiceCollection services)
    {
        // Register Swagger services
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();


        services.AddSwaggerGen(c =>
        {
            var programmers = string.Join("\n", programmerNames.Select(name => $"- {name}"));
            var provider = services.BuildServiceProvider().GetRequiredService<IApiDescriptionGroupCollectionProvider>();
            var endpointCount = provider.ApiDescriptionGroups.Items.SelectMany(group => group.Items).Count();

            // Get the base address from IHttpContextAccessor
            var httpContextAccessor = services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();
            var baseAddress = httpContextAccessor.HttpContext?.Request.Scheme + "://" + httpContextAccessor.HttpContext?.Request.Host.Value;

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Construction Management Assistant API Documentation",
                Description = $"Here Are {endpointCount} Endpoints\nBy Warriors:\n{programmers}.\n\nNavigate to : <b><a href=\"{baseAddress}/scalar/v1\">Scalar</a></b>",
                Version = "v1 Last Update 2025-01-21 2:32 PM"
            });

            // Optional: Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        // Configure CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()   // Allow requests from any origin
                      .AllowAnyMethod()   // Allow any HTTP method (GET, POST, etc.)
                      .AllowAnyHeader();  // Allow any HTTP headers
            });
        });

    }


    public static void UseSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Construction Management Assistant API Documentation");
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        });
    }
}

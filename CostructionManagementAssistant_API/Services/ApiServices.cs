namespace ConstructionManagementAssistant_API.Services;

public static class ApiServices
{
    public static void AddApiServices(this IServiceCollection services)
    {

        // Register global filters
        services.AddControllers(options => options.Filters.Add<ValidationFilter>());

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Construction Management Assistant APi Documenation",
                Description = "API documentation for the Construction Management Assistant application.",
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

}

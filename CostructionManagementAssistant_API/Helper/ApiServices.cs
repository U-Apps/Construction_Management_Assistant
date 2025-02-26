using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ConstructionManagementAssistant_API.Helper;

public static class ApiServices
{
    public static List<string> programmerNames = new List<string> { "Saleh Mohammed", "Yousef Abdollah", "Faroug Ali", "Ahemd Raid", "Faisal Omer", "Yamani Jamal", "Mohammad Saleh" };

    public static void AddApiServices(this IServiceCollection services)
    {
        // Register global filters and configure JSON options
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    // Extract validation errors from the ModelState
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(kvp => kvp.Value.Errors.Select(e => e.ErrorMessage))
                        .ToList();

                    // Create a BaseResponse<object> for the 400 Bad Request response
                    var response = new BaseResponse<object>
                    {
                        Success = false,
                        Message = "One or more validation errors occurred.",
                        Errors = errors
                    };

                    // Return a BadRequestObjectResult with the custom response
                    return new BadRequestObjectResult(response)
                    {
                        ContentTypes = { "application/json" }
                    };
                };
            });

        // Register IHttpContextAccessor
        services.AddHttpContextAccessor();

        // Register Swagger
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
}



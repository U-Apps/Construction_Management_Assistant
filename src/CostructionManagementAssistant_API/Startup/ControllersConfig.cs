namespace ConstructionManagementAssistant.API.Startup;

public static class ControllersConfig
{
    public static void AddControllersServices(this IServiceCollection services)
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
    }
}

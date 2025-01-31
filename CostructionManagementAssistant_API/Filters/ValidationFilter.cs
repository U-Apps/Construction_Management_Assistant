namespace ConstructionManagementAssistant_API.Filters;

/// <summary>
/// This filter isn't necessary because ASP.NET Core already handles validation bu using the [ApiController] atrribute, 
/// but it ensures a standard response format and logs validation errors.
/// </summary>
public class ValidationFilter(ILogger<ValidationFilter> _logger) : IAsyncActionFilter
{
    /// <summary>
    /// Executes the action filter asynchronously.
    /// </summary>
    /// <param name="context">The action executing context.</param>
    /// <param name="next">The delegate to execute the next action filter or action.</param>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Check if the model state is valid
        if (context.ModelState.IsValid)
        {
            // If valid, proceed to the next action filter or action
            await next();
            return;
        }

        // Collect validation errors from the model state
        var errors = context.ModelState
            .Where(ms => ms.Value?.Errors.Any() == true)
            .SelectMany(kvp => kvp.Value?.Errors.Select(e => $"{kvp.Key}: {e.ErrorMessage}") ?? Enumerable.Empty<string>())
            .ToList();

        foreach (var error in errors)
            _logger.LogWarning($"Validation error: {error}");

        // Create a standardized response with the validation errors
        var response = new BaseResponse<object>()
        {
            Success = false,
            Message = "Validation failed",
            Errors = errors,
        };
        context.Result = new BadRequestObjectResult(response);
    }
}

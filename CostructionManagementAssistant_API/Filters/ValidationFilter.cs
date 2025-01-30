namespace iCode.Ecommerce.Api.Filters;

/// <summary>
/// This filter isn't necessary because ASP.NET Core already handles validation bu using the [ApiController] atrribute, 
/// but it ensures a standard response format and logs validation errors.
/// </summary>
public class ValidationFilter(ILogger<ValidationFilter> _logger) : IAsyncActionFilter
{
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
            .Where(ms => ms.Value.Errors.Any())
            .SelectMany(kvp => kvp.Value.Errors.Select(e => $"{kvp.Key}: {e.ErrorMessage}"))
            .ToList();

        foreach (var error in errors)
            _logger.LogWarning($"Validation error: {error}");

        // Create a standardized response with the validation errors
        context.Result = new BadRequestObjectResult(new BaseResponse<object>(null, "Validation failed", errors, false));
    }
}

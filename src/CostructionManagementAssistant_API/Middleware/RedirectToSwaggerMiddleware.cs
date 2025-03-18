namespace ConstructionManagementAssistant.API.Middleware;

public class RedirectToSwaggerMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectToSwaggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await _next(context);
    }
}

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiServices();
builder.Services.AddCoreServices();
builder.Services.AddEFServices(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}
// Register the custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Use the custom middleware to redirect the base URL to Swagger
app.UseMiddleware<RedirectToSwaggerMiddleware>();

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

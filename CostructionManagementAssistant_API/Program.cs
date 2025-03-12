using ConstructionManagementAssistant_API.Startup;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersServices();
builder.Services.AddOpenApiServices();
builder.Services.AddSwaggerServices();
builder.Services.AddCoreServices();
builder.Services.AddEFServices(builder.Configuration);


var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerTool();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RedirectToSwaggerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();

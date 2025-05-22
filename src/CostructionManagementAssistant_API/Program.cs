using ConstructionManagementAssistant.API.Startup;
using ConstructionManagementAssistant.Core.Identity;
using ConstructionManagementAssistant.EF.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersServices();
builder.Services.AddOpenApiServices();
builder.Services.AddSwaggerServices();
builder.Services.AddCoreServices();
builder.Services.AddEFServices(builder.Configuration);
builder.Host.UseSerilogLoggging();

builder.Services.Configure<JWT>(builder.Configuration.GetSection("Jwt"));
var Jwt = builder.Configuration.GetSection("JWT").Get<JWT>();

var key = Encoding.ASCII.GetBytes(Jwt!.Key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false; // Set to true in production
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = Jwt.Audience,
        ValidIssuer = Jwt.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key)),
        ClockSkew = TimeSpan.Zero // Remove delay of token when expire
    };
});


builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 4;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseOpenApi();
app.UseSwaggerTool();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RedirectToSwaggerMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

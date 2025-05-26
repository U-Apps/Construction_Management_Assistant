using ConstructionManagementAssistant.API.Startup;
using ConstructionManagementAssistant.Core.Identity;
using ConstructionManagementAssistant.EF.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuestPDF.Infrastructure;
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

var Jwt = builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

var key = Encoding.ASCII.GetBytes(Jwt!.Key);

QuestPDF.Settings.License = LicenseType.Community; // or LicenseType.Commercial if applicable



builder.Services.Configure<OpenAIOptions>(
    builder.Configuration.GetSection("OpenAI"));



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


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = Jwt.Issuer,
        ValidAudience = Jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key)),
        ClockSkew = TimeSpan.Zero,
    };
});




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
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerTool();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RedirectToSwaggerMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

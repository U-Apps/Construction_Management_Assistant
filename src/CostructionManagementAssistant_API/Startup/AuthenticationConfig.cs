namespace ConstructionManagementAssistant.API.Startup;

public static class AuthenticationConfig
{

    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var Jwt = configuration.GetSection("JWT").Get<JWT>();

        //var key = Encoding.ASCII.GetBytes(Jwt!.Key);

        services.AddAuthentication(options =>
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

    }

    /// <summary>
    /// Configures ASP.NET Core Identity.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static void AddIdentity(this IServiceCollection services)
    {

        services.AddIdentity<AppUser, AppRole>(options =>
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

    }
}

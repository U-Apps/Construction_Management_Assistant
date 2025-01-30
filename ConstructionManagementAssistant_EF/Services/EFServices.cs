namespace ConstructionManagementAssistant_EF.Services;

public static class EFServices
{
    /// <summary>
    /// Adds the Entity Framework services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddEFServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RemoteConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'RemoteConnection' is not configured.");
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
}

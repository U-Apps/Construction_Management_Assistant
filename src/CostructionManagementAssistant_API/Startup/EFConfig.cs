using ConstructionManagementAssistant.EF.Repositories;

namespace ConstructionManagementAssistant.API.Startup;

public static class EFConfig
{
    public static void AddEF(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStrings.RemoteConnection);

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string '{connectionString}' is not configured.");
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            //options.EnableSensitiveDataLogging();
        });
    }
}
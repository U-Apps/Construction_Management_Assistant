using Supabase;

namespace ConstructionManagementAssistant.EF.Helper;

public static class EFServices
{
    /// <summary>
    /// Adds the Entity Framework services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddEFServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LocalConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'RemoteConnection' is not configured.");
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });
        services.AddScoped<Supabase.Client>(sp =>
        {
            var options = new SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };
           
            var client = new Supabase.Client("https://efpizvhwkfiqsrhpflcn.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVmcGl6dmh3a2ZpcXNyaHBmbGNuIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc0Njg2NDYwMCwiZXhwIjoyMDYyNDQwNjAwfQ.C1L-gUR9-kk_ZYt-CcUQEM-pwbHSoV_I_ktd4rGphpE", options);
            client.InitializeAsync().Wait(); // Ensure initialization before use
            return client;
        });
    }
}

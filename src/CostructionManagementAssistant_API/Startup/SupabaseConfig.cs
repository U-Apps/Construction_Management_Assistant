using Supabase;

namespace ConstructionManagementAssistant.API.Startup;

public static class SupabaseConfig
{
    public static void AddSupabase(this IServiceCollection services)
    {
        services.AddScoped<Supabase.Client>(sp =>
        {
            var options = new SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };

            var client = new Supabase.Client("https://efpizvhwkfiqsrhpflcn.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVmcGl6dmh3a2ZpcXNyaHBmbGNuIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc0Njg2NDYwMCwiZXhwIjoyMDYyNDQwNjAwfQ.C1L-gUR9-kk_ZYt-CcUQEM-pwbHSoV_I_ktd4rGphpE", options);
            client.InitializeAsync().Wait(); // Ensure initialization before use
            return client;
        });
    }
}

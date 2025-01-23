using ConstructionManagementAssistant_EF.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionManagementAssistant_EF.Configurations
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEntityFrameworkCoreServices(configuration);
        }

        private static IServiceCollection AddEntityFrameworkCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RemoteConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

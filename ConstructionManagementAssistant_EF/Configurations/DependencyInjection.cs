using ConstructionManagementAssistant_EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant_EF.Configurations
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBusinessCore(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEntityFrameworkCoreServices(configuration);
        }

        private static IServiceCollection AddEntityFrameworkCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

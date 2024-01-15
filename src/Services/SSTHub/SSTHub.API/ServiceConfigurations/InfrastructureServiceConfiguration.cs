using Microsoft.EntityFrameworkCore;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.API.ServiceConfigurations
{
    public static class InfrastructureServiceConfiguration
    {
        public static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SSTHubDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SSTHubDbConnection")));
        }
    }
}

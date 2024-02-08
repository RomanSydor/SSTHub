using Microsoft.EntityFrameworkCore;
using SSTHub.Identity.Data;

namespace SSTHub.Identity.ServiceConfiguration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SSTHubIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SSTHubIdentityDbConnection")));
        }
    }
}

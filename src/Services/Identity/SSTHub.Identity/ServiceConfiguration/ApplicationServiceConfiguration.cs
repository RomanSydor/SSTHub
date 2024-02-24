using SSTHub.Identity.Services;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.ServiceConfiguration
{
    public static class ApplicationServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);

            services.AddScoped<IAuthService, AuthService>();
        }
    }
}

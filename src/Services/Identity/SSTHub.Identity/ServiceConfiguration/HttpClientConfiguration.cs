using SSTHub.Identity.Services;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.ServiceConfiguration
{
    public static class HttpClientConfiguration
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IEmployeeService, EmployeeService>();
            services.AddHttpClient<IOrganizationService, OrganizationService>();
        }
    }
}

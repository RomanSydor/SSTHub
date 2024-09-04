using AutoMapper;
using SSTHub.Identity.Infrastructure.MappingProfiles;

namespace SSTHub.Identity.ServiceConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new EmployeeUserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

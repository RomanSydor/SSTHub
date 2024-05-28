using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.MappingProfiles;
using SSTHub.Infrastucture.Repositories.UnitOfWork;

namespace SSTHub.API.ServiceConfigurations
{
    public static class InfrastructureServiceConfiguration
    {
        public static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SSTHubDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SSTHubDbConnection")));
        }

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeProfile());
                mc.AddProfile(new HubProfile());
                mc.AddProfile(new ServiceProfile());
                mc.AddProfile(new EventProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
    }
}

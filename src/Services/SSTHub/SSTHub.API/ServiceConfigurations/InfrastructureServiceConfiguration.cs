using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using OData.Swagger.Services;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Infrastructure.Contexts;
using SSTHub.Infrastructure.MappingProfiles;
using SSTHub.Infrastructure.Repositories.UnitOfWork;

namespace SSTHub.API.ServiceConfigurations
{
    public static class InfrastructureServiceConfiguration
    {
        public static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SSTHubDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SSTHubDbConnection")));
            services.AddScoped<ISSTHubDbContext>(p => p.GetRequiredService<SSTHubDbContext>());
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
                mc.AddProfile(new CustomerProfile());
                mc.AddProfile(new OrganizationProfile());
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

        public static void AddControllersWithOdata(this IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Customer>(nameof(Customer));
            modelBuilder.EntitySet<Employee>(nameof(Employee));
            modelBuilder.EntitySet<Event>(nameof(Event));
            modelBuilder.EntitySet<Hub>(nameof(Hub));
            modelBuilder.EntitySet<Organization>(nameof(Organization));
            modelBuilder.EntitySet<Service>(nameof(Service));

            services
                .AddControllers()
                .AddOData(options => options
                    .Filter()
                    .OrderBy()
                    .Count()
                    .SetMaxTop(null)
                    .AddRouteComponents(model: modelBuilder.GetEdmModel())
                );

            services.AddOdataSwaggerSupport();
        }
    }
}

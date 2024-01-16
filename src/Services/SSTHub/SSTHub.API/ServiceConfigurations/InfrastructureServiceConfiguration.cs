﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;
using SSTHub.Infrastucture.MappingProfiles;
using SSTHub.Infrastucture.Repositories;

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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

﻿using SSTHub.Application.Infrastructure;
using SSTHub.Application.Services;
using SSTHub.Domain.Interfaces;

namespace SSTHub.API.ServiceConfigurations
{
    public static class ApplicationServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IHubService, HubService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IDateTimeService, DateTimeService>();
        }
    }
}

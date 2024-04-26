using MassTransit;

namespace SSTHub.Identity.ServiceConfiguration
{
    public static class MassTransitConfiguration
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("localhost", "/", c =>
                    {
                        c.Username(configuration["MassTransit:Username"]);
                        c.Password(configuration["MassTransit:Password"]);
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}

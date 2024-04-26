using MassTransit;
using SSTHub.EmailSender.Consumers;

namespace SSTHub.EmailSender.ServiceConfiguration
{
    public static class MassTransitConfiguration
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<EmailSendConsumer>();

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

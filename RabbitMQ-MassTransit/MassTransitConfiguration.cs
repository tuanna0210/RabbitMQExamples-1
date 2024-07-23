using MassTransit;
using System.Runtime.CompilerServices;

namespace RabbitMQ_MassTransit
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection ConfigMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MessageBroker:Host"]), c =>
                    {
                        c.Username(configuration["MessageBroker:Username"]);
                        c.Password(configuration["MessageBroker:Password"]);

                    });

                    configurator.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}

using Consumer.Consumers;
using MassTransit;

namespace Consumer
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection ConfigMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                //Add consumers
                //-By type
                //busConfigurator.AddConsumer<ArticleCreatedConsumer>();
                //-Add all consumers in the specified assembly
                busConfigurator.AddConsumers(typeof(ArticleCreatedConsumer).Assembly);

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

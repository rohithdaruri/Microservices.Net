using GreenPipes;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Service.Extensions
{
    public static class MassTransitExtension
    {
        public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumers(Assembly.GetEntryAssembly());

                configure.UsingRabbitMq((context, configurator) =>
                {
                    var configuration = context.GetService<IConfiguration>();
                    configurator.Host(configuration["RabbitMQSettings:Host"]);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(configuration["ServiceName"], false));
                    configurator.UseMessageRetry(retryConfigurator =>
                    {
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                    });
                });
            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}

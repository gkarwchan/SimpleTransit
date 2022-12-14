using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Simple.Broker.Consumers;

namespace Simple.Broker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        // By default, sagas are in-memory, but should be changed to a durable
                        // saga repository.
                        x.SetInMemorySagaRepositoryProvider();

                        var entryAssembly = Assembly.GetEntryAssembly();

                        x.AddConsumers(entryAssembly);
                        // x.AddConsumer<SubmitOrderConsumer>(typeof(SubmitOrderConsumerDefinition));
                        x.AddSagaStateMachines(entryAssembly);
                        x.AddSagas(entryAssembly);
                        x.AddActivities(entryAssembly);
                        
                        x.UsingRabbitMq((cxt, cfg) =>
                        {
                            cfg.Host("amqp://localhost:6672", h =>
                            {
                                h.Username("guest");
                                h.Username("guest");
                            });
                            cfg.ConfigureEndpoints(cxt);
                        });
                    });
                });
    }
}

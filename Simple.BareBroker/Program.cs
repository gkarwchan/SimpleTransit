// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Simple.BareBroker;

var isService = !(Debugger.IsAttached || args.Contains("--console"));
var builder = new HostBuilder()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", true);
        config.AddEnvironmentVariables();
        config.AddCommandLine(args);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);
        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumersFromNamespaceContaining<SubmitOrder>();
            cfg.AddBus(provider =>
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.ConfigureEndpoints(provider);
                });
            });
        });
        services.AddHostedService<MassTransitConsoleHostedService>();
    })
    .ConfigureLogging((hostContst, logging) =>
    {
        logging.AddConfiguration(hostContst.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });
    
if (isService)
    await builder.UseWindowsService().Build().StartAsync();
else
    await builder.RunConsoleAsync();
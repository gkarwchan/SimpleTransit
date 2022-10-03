
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", true);
        config.AddEnvironmentVariables();
        config.AddCommandLine(args);
    })
    .ConfigureServices((hostingContext, services) =>
    {
        //services.AddMassTransit()
    });
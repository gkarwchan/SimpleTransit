
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Hosting;

namespace Simple.BareBroker;

public class MassTransitConsoleHostedService : IHostedService
{
    private readonly IBusControl _bus;

    public MassTransitConsoleHostedService(IBusControl bus)
    {
        _bus = bus;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _bus.StartAsync(cancellationToken);
    }
}
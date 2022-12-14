using MassTransit;
using Microsoft.Extensions.Logging;
using Simple.Contracts;

namespace Simple.Consumers
{
    public class SubmitOrderConsumer :
        IConsumer<SubmitOrder>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.LogInformation("Received message: {customerNumber} and Id: {id}", context.Message.CustomerNumber, context.Message.OrderId);
            return Task.CompletedTask;
        }
    }
}
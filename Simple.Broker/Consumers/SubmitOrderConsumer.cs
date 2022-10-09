using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Simple.Contracts;

namespace Simple.Broker.Consumers
{
    public class SubmitOrderConsumer :
        IConsumer<SubmitOrder>
    {
        private readonly ILogger<SubmitOrder> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrder> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SubmitOrder> context)
        {
            context.RespondAsync(new SubmitOrderResponse
            {
                OrderId = context.Message.OrderId, Status = "Success"
            });
            return Task.CompletedTask;
        }
    }
}
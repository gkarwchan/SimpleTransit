using MassTransit;
using Microsoft.Extensions.Logging;
using Simple.Contracts;

namespace Simple.Consumers;

public class SubmitOrderConsumer : IConsumer<ISubmitOrder>
{
    private readonly ILogger<SubmitOrderConsumer> _logger;

    public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ISubmitOrder> context)
    {
        _logger.LogDebug("SubmitOrderConsumer: {CustomerNumber}", context.Message.CustomerNumber);
        if (context.Message.CustomerNumber.Contains("Test"))
        {
            await context.RespondAsync<ISubmissionOrderRejected>(
                new SubmissionOrderRejected
                {
                    OrderId = context.Message.OrderId,
                    Reason = "Test customer cannot test orders"
                });
        }
        else
        {
            await context.RespondAsync<ISubmitOrderSuccess>(
                new SubmitOrderSuccess
                {
                    OrderId = context.Message.OrderId, TimeStamp = DateTime.Now
                }
            );
            
        }
    }
}
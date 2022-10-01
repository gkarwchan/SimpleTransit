using MassTransit;
using Simple.Contracts;

namespace Simple.Consumers;

public class SubmitOrderConsumer : IConsumer<ISubmitOrder>
{
    public async Task Consume(ConsumeContext<ISubmitOrder> context)
    {
        await context.RespondAsync<ISubmitOrderSuccess>(
            new SubmitOrderSuccess
            {
                OrderId = context.Message.OrderId, TimeStamp = DateTime.Now
            }
        );
    }
}
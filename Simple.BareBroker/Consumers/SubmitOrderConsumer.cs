using Contracts;
using MassTransit;

namespace Simple.BareBroker.Consumers
{
    public class SubmitOrderConsumer :
        IConsumer<SubmitOrder>
    {
        public Task Consume(ConsumeContext<SubmitOrder> context)
        {
            return Task.CompletedTask;
        }
    }
}
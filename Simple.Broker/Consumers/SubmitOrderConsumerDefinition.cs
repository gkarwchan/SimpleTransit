using MassTransit;

namespace Simple.Broker.Consumers
{
    public class SubmitOrderConsumerDefinition :
        ConsumerDefinition<SubmitOrderConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SubmitOrderConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
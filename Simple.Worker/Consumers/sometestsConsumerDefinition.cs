namespace Company.Consumers
{
    using MassTransit;

    public class sometestsConsumerDefinition :
        ConsumerDefinition<sometestsConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<sometestsConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
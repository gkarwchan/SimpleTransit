using Microsoft.Extensions.Logging;

namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class sometestsConsumer :
        IConsumer<HelloMessage>
    {
        private readonly ILogger<sometestsConsumer> _logger;

        public sometestsConsumer(ILogger<sometestsConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<HelloMessage> context)
        {
            _logger.LogInformation("Hello {Name}", context.Message.Name);
            return Task.CompletedTask;
        }
    }
}
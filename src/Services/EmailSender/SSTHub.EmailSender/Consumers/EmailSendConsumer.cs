using MassTransit;
using SSTHub.Common.RabbitMQContracts;

namespace SSTHub.EmailSender.Consumers
{
    public class EmailSendConsumer : IConsumer<IEmailMessage>
    {
        public async Task Consume(ConsumeContext<IEmailMessage> context)
        {
            
        }
    }
}

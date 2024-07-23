using Common;
using MassTransit;

namespace Consumer.Consumers
{
    public class ArticleCreated2Consumer : IConsumer<ArticleCreatedEvent>
    {
        public Task Consume(ConsumeContext<ArticleCreatedEvent> context)
        {
            Console.WriteLine(context.Message.Title); 
            return Task.CompletedTask;
        }
    }
}

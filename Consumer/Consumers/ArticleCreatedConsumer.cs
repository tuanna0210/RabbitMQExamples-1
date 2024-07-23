using Common;
using MassTransit;

namespace Consumer.Consumers
{
    public sealed class ArticleCreatedConsumer : IConsumer<ArticleCreatedEvent>
    {

        public Task Consume(ConsumeContext<ArticleCreatedEvent> context)
        {
            Console.WriteLine(context.Message);
            return Task.FromResult(0);
        }
    }
}

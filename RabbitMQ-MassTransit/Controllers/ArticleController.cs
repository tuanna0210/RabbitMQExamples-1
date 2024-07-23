using Common;
using Common.IntergrationEvents;
using Contract.Enumerations;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQ_MassTransit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBus _bus;
        public ArticleController(IPublishEndpoint publishEndpoint, IBus bus)
        {
            _publishEndpoint = publishEndpoint;
            _bus = bus;
        }
        [HttpPost]
        public async Task<ActionResult> Create()
        {
            try
            {
                //Do things
                //Publish
                await _publishEndpoint.Publish(new DomainEvent.SMSNotificationEvent()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello",
                    Description = "SMS Description",
                    TimeStamp = DateTimeOffset.Now,
                    TransactionId = Guid.NewGuid(),
                    Type = NotificationType.sms
                });

                //Send
                //var endpoint = await _bus.GetSendEndpoint(new Uri("exchange:abc_def"));
                //await endpoint.Send(new ArticleCreatedEvent()
                //{
                //    Id = Guid.NewGuid(),
                //    Title = "News"
                //});
            }
            catch (Exception ex)
            {

            }
            
            return Ok();
        }
    }
}

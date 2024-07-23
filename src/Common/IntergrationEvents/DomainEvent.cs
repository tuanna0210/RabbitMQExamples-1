using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IntergrationEvents
{
    public static class DomainEvent
    {
        public record class EmailNotificationEvent : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }

        public record class SMSNotificationEvent : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }
    }
   
}

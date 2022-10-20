using NServiceBus;

namespace Billing.Messages.Commands
{
    public class OrderBilled : IEvent
    {
        public string OrderId { get; set; }
    }
}
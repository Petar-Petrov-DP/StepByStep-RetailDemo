﻿using NServiceBus;
using NServiceBus.Logging;
using Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Messages.Commands;

namespace Billing
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {

        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");

            var orderBilled = new OrderBilled
            {
                OrderId = message.OrderId
            };

            return context.Publish(orderBilled); ;
        }
       
    }
}
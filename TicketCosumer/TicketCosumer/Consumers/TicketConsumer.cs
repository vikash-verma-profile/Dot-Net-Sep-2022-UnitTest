using MassTransit;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCosumer.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        public Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            //throw new NotImplementedException();
            return Task.FromResult<object>(data);
        }
    }
}

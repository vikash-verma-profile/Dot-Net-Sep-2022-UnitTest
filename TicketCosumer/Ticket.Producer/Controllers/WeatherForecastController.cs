using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;
using MassTransit;

namespace Ticket.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBus bus;

        public WeatherForecastController(IBus _bus)
        {
            bus = _bus;
        }
        [HttpPost]
        [Route("CreateTicket")]
        public async Task<IActionResult> CreateTicket(Shared.Models.Ticket ticket)
        {
            if (ticket != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}

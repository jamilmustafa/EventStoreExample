using EventStoreExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EventStoreExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventStoreController : Controller
    {
        private readonly IEventStoreService eventStoreReposity;

        private readonly ILogger<EventStoreController> _logger;

        public EventStoreController(
            IEventStoreService eventStoreReposity,
            ILogger<EventStoreController> logger)
        {
            this.eventStoreReposity = eventStoreReposity;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult StoreEvent(double amount)
        {
            eventStoreReposity.AppendEvent(amount);
            return Ok();
           
        }
        [HttpGet]
        public IActionResult GetAmount(Guid streamId)
        {
            var res = eventStoreReposity.GetAmount(streamId);
            if (res != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("AllEvents")]
        public IActionResult GetAllEvents()
        {
            var res = eventStoreReposity.GetAllEvents();
            if (res != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

using EventStoreExample.Data;
using EventStoreExample.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EventStoreExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventStoreController : Controller
    {
        private readonly IEventStoreService eventStoreService;

        private readonly ILogger<EventStoreController> _logger;

        public EventStoreController(
            IEventStoreService eventStoreReposity,
            ILogger<EventStoreController> logger)
        {
            this.eventStoreService = eventStoreReposity;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult StoreEvent(double amount)
        {
            eventStoreService.AppendEvent(amount);
            return Ok();
           
        }
        [HttpGet]
        public double GetAmount(Guid streamId)
        {
            return eventStoreService.GetAmount(streamId);
            
        }
        [HttpGet]
        [Route("AllEvents")]
        public EventResponse GetAllEvents()
        {
            EventResponse response = eventStoreService.GetAllEvents();
            return response;

        }
    }
}

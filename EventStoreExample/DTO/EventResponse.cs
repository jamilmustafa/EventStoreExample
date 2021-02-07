using EventStoreExample.Data;
using System;
using System.Collections.Generic;

namespace EventStoreExample.DTO
{
    public class EventResponse
    {
        public List<EventModel> EventModels { get; set; }
        public Guid StreamId { get; set; }
    }
}

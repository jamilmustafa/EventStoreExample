using EventStoreExample.DTO;
using System;

namespace EventStoreExample.Data
{
    public class EventModel
    {
        public double Amount { get; set; }
        public Guid StreamId { get; set; }
    }
}

using EventStoreExample.DTO;
using System;

namespace EventStoreExample.DTO
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid StreamId { get; set; }
    }
}

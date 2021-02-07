using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreExample.DTO
{
    public class Command
    {
        public Guid EventId { get; set; }
    }
}

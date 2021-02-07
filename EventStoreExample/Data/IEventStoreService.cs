using EventStoreExample.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreExample.Data
{
    public interface IEventStoreService
    {
        void AppendEvent(double amount);
        double GetAmount(Guid streamId);
        EventResponse GetAllEvents();
    }
}

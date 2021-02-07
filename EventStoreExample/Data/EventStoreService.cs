using EventStoreExample.DTO;
using NEventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreExample.Data
{
    public class EventStoreService : IEventStoreService
    {
        readonly EventStore store;
        readonly Guid streamId;
        public EventStoreService()
        {
            store = new EventStore();
            streamId = Guid.NewGuid();
        }

        public void AppendEvent(double amount)
        {
            Command command = null;
            if (amount > 0)
            {
                command = new CashDepositCommandDTO { Amount = amount, EventId = Guid.NewGuid() };
            }
            else if(amount<0) {
                command = new CashWithdrawalCommandDTO { Amount = amount, EventId = Guid.NewGuid() };
            }
            using (IEventStream stream = store._store.OpenStream(streamId, 0, int.MaxValue))
            {
                stream.Add(new EventMessage
                {
                    Body = command
                });
                stream.CommitChanges(command.EventId);
            }
            
        }

       

        public double GetAmount(Guid streamId)
        {
            double result = 0;
            using (var stream = store._store.OpenStream(streamId, 0, int.MaxValue))
            {
                foreach (dynamic item in stream.CommittedEvents)
                {
                    result += item.Body.Amount;
                }
            }
            return result;
        }
        public EventResponse GetAllEvents()
        {
            List<EventModel> eventModels = new List<EventModel>();
            using (var stream = store._store.OpenStream(streamId, 0, int.MaxValue))
            {
                foreach (dynamic item in stream.CommittedEvents)
                {
                    eventModels.Add(new EventModel
                    {
                        Amount = item.Body.Amount,
                        StreamId = streamId,
                        Id=item.Body.EventId
                        
                    });
                }
            }
            return new EventResponse { 
                 EventModels=eventModels,
                 StreamId=streamId
            };
        }
    }
}

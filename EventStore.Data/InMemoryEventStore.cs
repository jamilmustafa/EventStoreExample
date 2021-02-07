using EventStore.Core;
using NEventStore;
using NEventStore.Serialization.Json;
using System;
namespace EventStore.Data
{
    public class InMemoryEventStore : IEventStoreData
    {
        private IStoreEvents _store;
        public InMemoryEventStore()
        {
            _store = Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .UsingJsonSerialization().Build();

        }
        public void AppendToStream(Guid streamId, Command command)
        {
            using (IEventStream stream = _store.OpenStream(streamId, 0, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = command });
                stream.CommitChanges(command.EventId);

            }
                
        }
    }
}

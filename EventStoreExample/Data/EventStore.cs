using NEventStore;
using NEventStore.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreExample.Data
{
    public class EventStore : IDisposable
    {
        public IStoreEvents _store;
        public EventStore()
        {
            _store = Wireup.Init()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Build();
        }

        public void Dispose()
        {
            _store.Dispose();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
namespace EventStore.Data
{
    public interface IEventStoreData
    {
       public void AppendToStream(Guid streamId, Command command);
    }
}

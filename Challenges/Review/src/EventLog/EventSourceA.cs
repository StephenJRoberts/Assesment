using System;

namespace EventLog
{
    class EventSourceA : IEventSource
    {
        public event EventHandler EventOccured;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

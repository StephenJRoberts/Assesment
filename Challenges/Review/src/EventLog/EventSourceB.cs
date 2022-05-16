using System;
using System.Collections.Generic;
using System.Text;

namespace EventLog
{
    class EventSourceB : IEventSource
    {
        public event EventHandler EventOccured;

        public void Dispose()
        {
            EventOccured?.Invoke(this, EventArgs.Empty);
        }
    }
}

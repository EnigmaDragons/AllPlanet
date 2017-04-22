using MonoDragons.Core.Engine;
using System.Collections.Generic;

namespace MonoDragons.Core.EventSystem
{
    public class EventBuffer
    {
        private List<object> events = new List<object>();
        public bool HasNext => events.Count > 0;
        public object Event
        {
            get
            {
                var e = events[0];
                events.RemoveAt(0);
                return e;
            }
        }
        
        public EventBuffer()
        {
        }

        public void Subscribe<T>()
        {
            World.Subscribe(EventSubscription.Create<T>((e) => events.Add(e), this));
        }
    }
}

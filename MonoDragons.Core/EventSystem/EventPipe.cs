using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace MonoDragons.Core.EventSystem
{
    public class EventPipe
    {
        private List<Action> actions = new List<Action>();
        public bool HasNext => actions.Count > 0;
        
        public EventPipe()
        {
        }

        public void Subscribe<T>(Action<T> act)
        {
            World.Subscribe(EventSubscription.Create<T>((e) => actions.Add(() => act(e)), this));
        }

        public void Dequeue()
        {
            actions[0]();
            actions.RemoveAt(0);
        }
    }
}

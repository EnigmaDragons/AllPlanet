using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Transitions
{
    public class Transition
    {
        public static Transition None = new Transition("None");

        public string Name { get; }
        private readonly Mode _mode = Mode.Presentation;
        private readonly List<object> _transitionaryEvents;

        public Transition(string name, params object[] transitionaryEvents)
        {
            Name = name;
            _transitionaryEvents = transitionaryEvents.ToList();
        }

        public void Start()
        {
            World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this));
            World.Publish(new ModeChanged(_mode));
            Continue();
        }

        private void Continue()
        {
            if (_transitionaryEvents.Count == 0)
            {
                World.Unsubscribe(this);
            }
            else
            {
                var e = _transitionaryEvents[0];
                _transitionaryEvents.RemoveAt(0);
                World.Publish(e);
            }
        }
    }
}

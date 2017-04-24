using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Transitions
{
    public class Transition
    {
        public static Transition None = new Transition("None", Mode.Presentation);

        public string Name { get; }
        private readonly Mode _mode;
        private readonly List<object> _transitionaryEvents;

        public Transition(string name, Mode mode, params object[] transitionaryEvents)
        {
            _mode = mode;
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

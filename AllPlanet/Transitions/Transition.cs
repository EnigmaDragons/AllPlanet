using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument
{
    public class Transition
    {
        public string Name { get; }
        private readonly List<object> _transitionaryEvents;

        public Transition(string name, params object[] transitionaryEvents)
        {
            Name = name;
            _transitionaryEvents = transitionaryEvents.ToList();
        }
    }
}

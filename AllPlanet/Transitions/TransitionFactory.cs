using System.Collections.Generic;
using AllPlanet.Transitions.Concrete;

namespace AllPlanet.Transitions
{
    public class TransitionFactory
    {
        private static Dictionary<string, Transition> _transitions = new Dictionary<string, Transition>
        {
            { Opening.Transition.Name, Opening.Transition },
        };

        public static bool Exists(string name)
        {
            return _transitions.ContainsKey(name);
        }

        public static Transition Create(string name)
        {
            return _transitions[name];
        }
    }
}

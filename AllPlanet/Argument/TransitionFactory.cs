using System.Collections.Generic;
using AllPlanet.Argument.Concrete;

namespace AllPlanet.Argument
{
    public class TransitionFactory
    {
        private static Dictionary<string, Transition> _transitions = new Dictionary<string, Transition>
        {
            { Opening.Transition.Name, LavaArgument.Transition },
        };

        public static Transition Create(string name)
        {
            return _transitions[name];
        }
    }
}

using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPlanet.Transitions
{
    public class CurrentTransition
    {
        private Transition _currentArgument;

        public CurrentTransition()
        {
            _currentArgument = Transition.None;
            World.Subscribe(EventSubscription.Create<Segue>(Segue, this));
        }

        public Transition Get()
        {
            return _currentArgument;
        }

        private void Segue(Segue obj)
        {
            if (TransitionFactory.Exists(obj.ArgumentName))
            {
                _currentArgument = TransitionFactory.Create(obj.ArgumentName);
                _currentArgument.Start();
            }
            else
                _currentArgument = Transition.None;
        }
    }
}

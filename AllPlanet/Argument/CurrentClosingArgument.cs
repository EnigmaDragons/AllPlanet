using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System.Collections.Generic;

namespace AllPlanet.Argument
{
    public class CurrentClosingArgument
    {
        private ClosingArgument _currentArgument;

        public CurrentClosingArgument()
        {
            _currentArgument = ClosingArgument.None;
            World.Subscribe(EventSubscription.Create<Segue>(Segue, this));
        }

        public ClosingArgument Get()
        {
            return _currentArgument;
        }

        private void Segue(Segue obj)
        {
            try
            {
                _currentArgument = ClosingArgumentFactory.Create(obj.ArgumentName);
                _currentArgument.Start();
            }
            catch (KeyNotFoundException)
            {
                _currentArgument = ClosingArgument.None;
            }
        }
    }
}

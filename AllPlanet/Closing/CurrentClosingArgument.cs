using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Closing
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
            if (ClosingArgumentFactory.Exists(obj.ArgumentName))
            {
                _currentArgument = ClosingArgumentFactory.Create(obj.ArgumentName);
                _currentArgument.Start();
            }
            else
                _currentArgument = ClosingArgument.None;
        }
    }
}

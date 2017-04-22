using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Argument
{
    public class CurrentPoint
    {
        private ArgumentPoint _currentPoint;

        public CurrentPoint()
        {
            _currentPoint = ArgumentPoint.None;
            World.Subscribe(EventSubscription.Create<Segue>(Segue, this));
        }

        public ArgumentPoint Get()
        {
            return _currentPoint;
        }

        private void Segue(Segue obj)
        {
            _currentPoint = ArgumentPointFactory.Create(obj.ArgumentName);
            World.Publish(new StatementChanged(_currentPoint.CurrentStatement));
        }
    }
}

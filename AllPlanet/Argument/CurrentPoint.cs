﻿using MonoDragons.Core.Engine;
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
            try
            {
                _currentPoint = ArgumentPointFactory.Create(obj.ArgumentName);
                _currentPoint.Start();
            }
            catch
            {
                _currentPoint = ArgumentPoint.None;
            }
        }
    }
}

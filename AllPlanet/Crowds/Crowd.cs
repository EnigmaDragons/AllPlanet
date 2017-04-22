using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Crowds
{
    public class Crowd
    {
        private int _score = 0;

        public Crowd()
        {
            World.Subscribe(EventSubscription.Create<Score>((s) => _score += s.Points, this));
        }
    }
}

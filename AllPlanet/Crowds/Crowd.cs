using System;
using AllPlanet.Argument;
using AllPlanet.Closing;
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
            World.Subscribe(EventSubscription.Create<EndOfArgument>(Vote, this));
        }

        private void Vote(EndOfArgument obj)
        {
            if (_score > 0)
                obj.Argument.Vote(true);
            else
                obj.Argument.Vote(false);
        }
    }
}

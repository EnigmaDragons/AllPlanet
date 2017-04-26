using AllPlanet.Argument;
using AllPlanet.Closing;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Crowds
{
    public class Crowd
    {
        private int _score = 0;
        private int[] _scoreRequirements;
        private int _indexer = 0;

        public Crowd(params int[] scoreRequirements)
        {
            _scoreRequirements = scoreRequirements;
            World.Subscribe(EventSubscription.Create<Score>((s) => _score += s.Points, this));
            World.Subscribe(EventSubscription.Create<EndOfArgument>(Vote, this));
        }

        private void Vote(EndOfArgument obj)
        {
            if (_scoreRequirements.Length > _indexer ? _score > _scoreRequirements[_indexer] : _score > 0)
                obj.Argument.Vote(true);
            else
                obj.Argument.Vote(false);
            _score = 0;
            _indexer++;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using AllPlanet.Player;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Argument
{
    public class RefuteOption
    {
        public ArgumentType Type { get; }

        private readonly string _nextArgumentName;
        private readonly List<object> _responses;
        private readonly int _score;

        public RefuteOption(ArgumentType arguementType, string nextArgumentName, params object[] responses)
            : this(arguementType, nextArgumentName, 0, responses) { }

        public RefuteOption(ArgumentType arguementType, string nextArgumentName, int score, params object[] responses)
        {
            Type = arguementType;
            _nextArgumentName = nextArgumentName;
            _responses = responses.ToList();
            _score = score;
        }

        public void Choose()
        {
            World.Publish(new Score(_score));
            World.Subscribe(EventSubscription.Create<AdvanceRequested>(x => Continue(), this));
            Continue();
        }

        private void Continue()
        {
            if (_responses.Count == 0)
            {
                World.Unsubscribe(this);
                World.Publish(new Segue(_nextArgumentName));
            }
            else
            {
                World.Publish(_responses[0]);
                _responses.RemoveAt(0);
            }
        }
    }
}
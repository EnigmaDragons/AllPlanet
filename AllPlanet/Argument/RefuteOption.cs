using System.Collections.Generic;
using System.Linq;
using AllPlanet.Closing;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Argument
{
    public class RefuteOption
    {
        public ArgumentType Type { get; }

        private readonly string _concludingArgument;
        private readonly string _closingLock;
        private readonly string _closingUnlock;
        private readonly string _nextArgumentName;
        private readonly List<object> _responses;
        private readonly int _score;

        public RefuteOption(ArgumentType argumentType, string nextArgumentName, int score, params object[] responses)
            : this("", "", "", argumentType, nextArgumentName, score, responses) { }
        public RefuteOption(string concludingArgumentName, string closingUnlock, string closingLock, ArgumentType argumentType,
            string nextArgumentName, int score, params object[] responses)
        {
            _concludingArgument = concludingArgumentName;
            _closingLock = closingLock;
            _closingUnlock = closingUnlock;
            Type = argumentType;
            _nextArgumentName = nextArgumentName;
            _responses = responses.ToList();
            _score = score;
        }

        public void Choose()
        {
            if (_closingUnlock != "")
            {
                var argument = ClosingArgumentFactory.Create(_concludingArgument);
                argument.Unlock(_closingUnlock);
            }
            if (_closingLock != "")
            {
                var argument = ClosingArgumentFactory.Create(_concludingArgument);
                argument.Lock(_closingLock);
            }
            World.Publish(new Score(_score));
            World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this));
            World.Publish(new ModeChanged(Mode.Presentation));
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
                var r = _responses[0];
                _responses.RemoveAt(0);
                World.Publish(r);
            }
        }
    }
}
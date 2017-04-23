using System.Collections.Generic;
using System.Linq;
using AllPlanet.Planet;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System;

namespace AllPlanet.Argument
{
    public class ClosingOption
    {
        public string Description { get; }
        private readonly int _points;
        private List<object> _responses { get; }
        private Action _callback;

        public ClosingOption(string description, int points, params object[] responses)
        {
            Description = description;
            _points = points;
            _responses = responses.ToList();
        }

        public void Enact(Action callback)
        {
            _callback = callback;
            World.Publish(new Score(_points));
            World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this));
            World.Publish(new ModeChanged(Mode.Presentation));
            Continue();
        }

        private void Continue()
        {
            if (_responses.Count == 0)
            {
                World.Unsubscribe(this);
                _callback();
            }
            else
            {
                World.Publish(_responses[0]);
                _responses.RemoveAt(0);
            }
        }
    }
}

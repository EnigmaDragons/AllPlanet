using System;
using System.Collections.Generic;
using System.Linq;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Closing
{
    public class ClosingOption
    {
        public string Name { get; }
        public string Description { get; }
        public bool Unlocked { get; set; }
        private readonly int _points;
        private List<object> _responses { get; }
        private Action _callback;

        public ClosingOption(string description, int points, params object[] responses) : this("", true, description, points, responses) { }
        public ClosingOption(string name, bool unlocked, string description, int points, params object[] responses)
        {
            Unlocked = unlocked;
            Name = name;
            Description = description;
            _points = points;
            _responses = responses.ToList();
        }

        public void Enact(Action callback)
        {
            _callback = callback;
            World.Publish(new Score(_points));
            World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this));
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
                var r = _responses[0];
                _responses.RemoveAt(0);
                World.Publish(r);
            }
        }
    }
}

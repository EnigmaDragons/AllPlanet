using System;
using System.Collections.Generic;
using System.Linq;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Closing
{
    public class ClosingChoice
    {
        public List<string> OptionNames => _options.Select((o) => o.Name).ToList();
        public List<string> AvailableOptionDescriptions => _options.Where((o) => o.Unlocked).Select((o) => o.Description).ToList();
        private List<ClosingOption> _options { get; }
        private List<object> _responses { get; }
        private ClosingOption _chosenOption;
        private Action _callback;

        public ClosingChoice(object[] openingResponses, params ClosingOption[] options)
        {
            _options = options.ToList();
            _responses = openingResponses.ToList();
        }

        public void Unlock(string name)
        {
            _options.Find((o) => o.Name == name).Unlocked = true;
        }

        public void Lock(string name)
        {
            _options.Find((o) => o.Name == name).Unlocked = false;
        }

        public void Enact(string optionDescription, Action callback)
        {
            _callback = callback;
            _chosenOption = _options.Find(c => c.Description == optionDescription);
            World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this));
            Continue();
        }

        private void Continue()
        {
            if (_responses.Count == 0)
            {
                World.Unsubscribe(this);
                _chosenOption.Enact(() => _callback());
            }
            else
            {
                World.Publish(_responses[0]);
                _responses.RemoveAt(0);
            }
        }
    }
}

using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument
{
    public class ClosingChoice
    {
        public List<string> OptionDescriptions => _options.Select((o) => o.Description).ToList();
        private List<ClosingOption> _options { get; }
        private List<object> _responses { get; }
        private Action _callback;

        public ClosingChoice(object[] responses, params ClosingOption[] options)
        {
            _options = options.ToList();
            _responses = responses.ToList();
        }

        public void Enact(string optionDescription, Action callback)
        {
            _callback = callback;
            var option = _options.Find(c => c.Description == optionDescription);
            option.Enact(() => { World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Continue(), this)); Continue(); } );
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

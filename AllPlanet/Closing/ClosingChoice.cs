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
        private ClosingChoice[][] _addedChoices;
        private Action _callback;

        public ClosingChoice(object[] openingResponses, params ClosingOption[] options)
            : this(null, openingResponses, options)
        {
            _addedChoices = new ClosingChoice[options.Count()][];
            for (var i = 0; i < _addedChoices.Length; i++)
                _addedChoices[i] = new ClosingChoice[0];
        }

        public ClosingChoice(ClosingChoice[][] addedChoices, object[] openingResponses, params ClosingOption[] options)
        {
            _addedChoices = addedChoices;
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

        public ClosingChoice[] Choose(string optionDescription)
        {
            _chosenOption = _options.Find(c => c.Description == optionDescription && c.Unlocked);
            var index = _options.IndexOf(_chosenOption);
            return _addedChoices[index];
        }

        public void Enact(Action callback)
        {
            _callback = callback;
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
                var r = _responses[0];
                _responses.RemoveAt(0);
                World.Publish(r);
            }
        }
    }
}

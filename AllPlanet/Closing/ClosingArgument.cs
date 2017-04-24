using System.Collections.Generic;
using System.Linq;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using AllPlanet.Transitions;
using AllPlanet.Scenes;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Closing
{
    public class ClosingArgument
    {
        public static ClosingArgument None = new ClosingArgument("None", Transition.None, Transition.None,
            new ClosingChoice(new object[0], new ClosingOption("None", 0)));

        public string Name { get ; }
        private List<ClosingChoice> _choices;
        private List<string> _chosenOptions = new List<string>();
        public ClosingChoice CurrentChoice { get; private set; }
        private int _indexer = 0;
        private Transition _playerVictory;
        private Transition _playerDefeat;

        public ClosingArgument(string name, Transition playerVictory, Transition playerDefeat, params ClosingChoice[] choices)
        {
            _playerVictory = playerVictory;
            _playerDefeat = playerDefeat;
            Name = name;
            _choices = choices.ToList();
            CurrentChoice = _choices.ElementAt(0);
        }

        public void Unlock(string optionName)
        {
            _choices.Find((c) => c.OptionNames.Exists((o) => o == optionName)).Unlock(optionName);
        }

        public void Lock(string optionName)
        {
            _choices.Find((c) => c.OptionNames.Exists((o) => o == optionName)).Lock(optionName);
        }

        public void Start()
        {
            World.SubscribeForScene(EventSubscription.Create<NavigateToScene>((n) => World.NavigateToScene(n.Scene), this));
            World.Publish(new ModeChanged(Mode.ClosingArgument));
        }

        public void Choose(string optionDescription)
        {
            _indexer++;
            _chosenOptions.Add(optionDescription);
            if (_choices.Count != _chosenOptions.Count)
                CurrentChoice = _choices.ElementAt(_indexer);
            else
            {
                World.Publish(new ModeChanged(Mode.Presentation));
                _indexer = 0;
                _choices[_indexer].Enact(_chosenOptions[_indexer], Continue);
            }
        }

        private void Continue()
        {
            _indexer++;
            if(_indexer < _choices.Count)
                _choices[_indexer].Enact(_chosenOptions[_indexer], Continue);
            else
                World.Publish(new EndOfArgument(this));
        }

        public void Vote(bool victory)
        {
            if (victory)
                _playerVictory.Start();
            else
                _playerDefeat.Start();
        }
    }
}

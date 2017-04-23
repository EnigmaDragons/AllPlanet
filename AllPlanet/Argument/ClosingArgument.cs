using MonoDragons.Core.Engine;
using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument
{
    public class ClosingArgument
    {
        public static ClosingArgument None = new ClosingArgument("None", new ClosingChoice(new object[0], new ClosingOption("None", 0)));

        public string Name { get ; }
        private List<ClosingChoice> _choices;
        private List<string> _chosenOptions = new List<string>();
        public ClosingChoice CurrentChoice { get; private set; }
        private int _indexer = 0;

        public ClosingArgument(string name, params ClosingChoice[] choices)
        {
            Name = name;
            _choices = choices.ToList();
            CurrentChoice = _choices.ElementAt(0);
        }

        public void Start()
        {
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
        }
    }
}

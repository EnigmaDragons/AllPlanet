using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument.Concrete
{
    public class ClosingArgument
    {
        private List<ClosingChoice> _choices;
        private List<string> _chosenOptions = new List<string>();
        public ClosingChoice CurrentChoice { get; private set; }
        private int _indexer = 0;

        public ClosingArgument(params ClosingChoice[] choices)
        {
            _choices = choices.ToList();
            CurrentChoice = _choices.ElementAt(0);
        }

        public void Choose(string optionDescription)
        {
            _indexer++;
            _chosenOptions.Add(optionDescription);
            if (_choices.Count != _chosenOptions.Count)
                CurrentChoice = _choices.ElementAt(_indexer);
            else
            {
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

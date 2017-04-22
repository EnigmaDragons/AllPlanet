using System.Collections.Generic;
using System.Linq;
using AllPlanet.Opponent;

namespace AllPlanet.Argument
{
    public class Statement
    {
        private readonly List<RefuteOption> _options;

        public string Message { get; }
        public OpponentExpression Expression { get; }
        public List<string> Options => _options.Select(c => c.Name).ToList();
        public bool IsRefutable => Options.Count > 0;

        public Statement(string message, List<RefuteOption> options)
        {
            Message = message;
            _options = options;
        }

        public void Counter(string optionName)
        {
            var counter = _options.Find(c => c.Name == optionName);
            counter.Choose();
            _options.Remove(counter);
        }
    }
}
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
        public List<ArgumentType> Options => _options.Select(c => c.Type).ToList();
        public bool IsRefutable => Options.Count > 0;

        public Statement(string message, OpponentExpression expression, params RefuteOption[] options)
        {
            Message = message;
            Expression = expression;
            _options = options.ToList();
        }

        public void Refute(ArgumentType optionName)
        {
            var counter = _options.Find(c => c.Type == optionName);
            counter.Choose();
            _options.Remove(counter);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AllPlanet.Opponent;

namespace AllPlanet.Argument
{
    public class Statement
    {
        private readonly List<RefuteOption> _options;
        private readonly Dictionary<string, RefuteOption> _discredits;
        private readonly RefuteOption _genericDiscredit;

        public string Message { get; }
        public OpponentExpression Expression { get; }
        public List<ArgumentType> Options => _options.Select(c => c.Type).ToList();
        public bool IsRefutable => Options.Count > 0;

        public Statement(string message, OpponentExpression expression, RefuteOption genericDiscredit, params RefuteOption[] options)
            : this(message, expression, new Dictionary<string, RefuteOption>(), genericDiscredit, options) {}

        public Statement(string message, OpponentExpression expression, 
            Dictionary<string, RefuteOption> discredits, RefuteOption genericDiscredit, params RefuteOption[] options)
        {
            Message = message;
            Expression = expression;
            _options = options.ToList();
            _discredits = discredits;
            _genericDiscredit = genericDiscredit;
        }

        public void Refute(ArgumentType optionName)
        {
            var counter = _options.Find(c => c.Type == optionName);
            counter.Choose();
            _options.Remove(counter);
        }

        public void Discredit(string statement)
        {
            if(_discredits.ContainsKey(statement))
            {
                var discredit = _discredits[statement];
                _discredits.Remove(statement);
                discredit.Choose();
            }
            else
                _genericDiscredit.Choose();
        }
    }
}
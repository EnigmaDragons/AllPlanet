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
        public List<string> Options => _options.Select(c => c.Name).ToList();
        public bool IsRefutable => Options.Count > 0;

        public Statement(string message, List<RefuteOption> options, Dictionary<string, RefuteOption> discredits, RefuteOption genericDiscredit)
        {
            Message = message;
            _options = options;
            _discredits = discredits;
            _genericDiscredit = genericDiscredit;
        }

        public void Counter(string optionName)
        {
            var counter = _options.Find(c => c.Name == optionName);
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
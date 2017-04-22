using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Refute
{
    public class Statement
    {
        public string Comment;
        private List<Counter> _counters;
        public List<string> Counters => _counters.Select((c) => c.Statement).ToList();
        public bool IsRefutable => Counters.Count > 0;

        public Statement(string comment, List<Counter> counters)
        {
            Comment = comment;
            _counters = counters;
        }

        public void Counter(string counterStatement)
        {
            var counter = _counters.Find((c) => c.Statement == counterStatement);
            counter.Go();
            _counters.Remove(counter);
        }
    }
}
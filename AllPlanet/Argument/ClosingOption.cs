using System.Collections.Generic;
using System.Linq;
using AllPlanet.Planet;

namespace AllPlanet.Argument
{
    public class ClosingOption
    {
        public string Description { get; }
        private readonly int _points;
        public List<object> Responses { get; }

        public ClosingOption(string description, int points, params object[] responses)
        {
            Description = description;
            _points = points;
            Responses = responses.ToList();
        }
    }
}

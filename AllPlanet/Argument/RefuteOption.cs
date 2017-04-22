using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Engine;

namespace AllPlanet.Argument
{
    public class RefuteOption
    {
        public ArgumentType Type { get; }

        private readonly string _nextNextArgumentName;
        private readonly List<object> _responses;

        public RefuteOption(ArgumentType arguementType, string nextArgumentName, params object[] responses)
        {
            Type = arguementType;
            _nextNextArgumentName = nextArgumentName;
            _responses = responses.ToList();
        }

        public void Choose()
        {
            _responses.ForEach(World.Publish);
            World.Publish(new Segue(_nextNextArgumentName));
        }
    }
}
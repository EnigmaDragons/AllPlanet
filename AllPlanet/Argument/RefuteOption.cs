using System.Collections.Generic;
using System.Linq;
using AllPlanet.Crowd;
using AllPlanet.Planet;
using MonoDragons.Core.Engine;

namespace AllPlanet.Argument
{
    public class RefuteOption
    {
        public ArgumentType Type { get; }

        private readonly string _nextArgumentName;
        private readonly List<object> _responses;

        public RefuteOption(ArgumentType arguementType, string nextArgumentName, params object[] responses)
        {
            Type = arguementType;
            _nextArgumentName = nextArgumentName;
            _responses = responses.ToList();
        }

        public void Choose()
        {
            // TODO: Kill this once Event Publishing is upgraded
            _responses.ForEach(PublishRetyped);
            World.Publish(new ReadyForSegue(_nextArgumentName));
        }

        private void PublishRetyped(object o)
        {
            if (o is PlanetResponds)
                World.Publish((PlanetResponds)o);
            if (o is CrowdResponds)
                World.Publish((CrowdResponds)o);
            if (o is OpponentResponds)
                World.Publish((OpponentResponds)o);
        }
    }
}
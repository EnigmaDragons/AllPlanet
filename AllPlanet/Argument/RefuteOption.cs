using AllPlanet.Crowd;
using AllPlanet.Planet;
using MonoDragons.Core.Engine;

namespace AllPlanet.Argument
{
    public class RefuteOption
    {
        public string Name { get; }
        private readonly PlanetResponds _planetResponse;
        private readonly OpponentResponds _opponentsResponse;
        private readonly CrowdExpression _crowdExpression;
        private readonly string _arguementName;

        public RefuteOption(string name, PlanetResponds planetResponse, OpponentResponds opponentsResponse, CrowdExpression crowdExpression, string arguementName)
        {
            Name = name;
            _planetResponse = planetResponse;
            _opponentsResponse = opponentsResponse;
            _crowdExpression = crowdExpression;
            _arguementName = arguementName;
        }

        public void Choose()
        {
            World.Publish(_planetResponse);
            World.Publish(_opponentsResponse);
            World.Publish(new CrowdExpresses(_crowdExpression));
            World.Publish(new Segue(_arguementName));
        }
    }
}
using System.Collections.Generic;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete
{
    public class MoonsAreNotGoodArgument
    {
        public ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I have never had a moon.*", PlanetExpression.Thinking),
                new OpponentResponds("Did you know saturn has meteor showers all the time.", OpponentExpression.Challenging),
                new OpponentResponds("Why because all those damn moons and astroids it has!", OpponentExpression.Worried),
                new OpponentResponds("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
            }, 
            "moons are not good", 
            new Statement("Did you know saturn has meteor showers all the time.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good")),
            new Statement("Why because all those damn moons and astroids it has!", OpponentExpression.Worried, GenericDiscreditResponse.Create("moons are not good")),
            new Statement("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good")));
    }
}

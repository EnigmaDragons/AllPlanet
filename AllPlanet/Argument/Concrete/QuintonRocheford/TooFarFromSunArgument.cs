using System.Collections.Generic;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete
{
    public static class TooFarFromSunArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("This next point, should shed some light on this situation.", OpponentExpression.Proud),
                new PlanetResponds("*What's that supposed to mean*", PlanetExpression.Thinking),
                new OpponentResponds("There is a place known as the Kuiper belt. This is the outer ring of our solar system.", OpponentExpression.Challenging),
                new OpponentResponds("This place has many larger ice bodies that are not considered planets.", OpponentExpression.Proud),
                new OpponentResponds("You are far enough away from the sun, you are in this belt.", OpponentExpression.Proud),
                new OpponentResponds("Therefore you should not be considered a planet", OpponentExpression.Challenging),
            }, 
            "too far from sun"
            );
    }
}

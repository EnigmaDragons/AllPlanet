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
                new OpponentResponds("There is a place known as the Kuiper belt.", OpponentExpression.Challenging),
                new OpponentResponds("This is the outer ring of our solar system.", OpponentExpression.Proud),
                new OpponentResponds("This place has many many ice bodies that are not considered planets.", OpponentExpression.Proud),
                new OpponentResponds("You are so far from the sun, that I claim you are part of that belt.", OpponentExpression.Challenging),
                new OpponentResponds("You are so far from the sun, you should not be considered a planet.", OpponentExpression.Challenging),
            }, 
            "too far from sun"
            );
    }
}

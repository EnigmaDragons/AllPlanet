using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete
{
    public static class GravityIsTooWeakArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("I don't think you understand the gravity of this situation.", OpponentExpression.Proud),
                new PlanetResponds("*What does that mean?*", PlanetExpression.Thinking),
                new OpponentResponds("I am able to stand on this podium without so much as a pull from your gravity.", OpponentExpression.Proud),
                new OpponentResponds("That's the reason you don't have a moon.", OpponentExpression.Challenging),
                new OpponentResponds("You're gravity is practically non-existent.", OpponentExpression.Proud),
                new OpponentResponds("Planet's are formed by gravity pulling things together.", OpponentExpression.Challenging),
                new OpponentResponds("With no gravity like that, you are not a planet.", OpponentExpression.Challenging),
                new CrowdResponds(CrowdExpression.NoComment),
            }, 
            "gravity is too weak");
    }
}

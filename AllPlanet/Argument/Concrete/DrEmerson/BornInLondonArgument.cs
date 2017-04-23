using System.Collections.Generic;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class BornInLondonArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I bet he is out of good arguments*", PlanetExpression.Thinking),
                new OpponentResponds("I have with me some irruftuable evidence that you are not a planet.", OpponentExpression.Challenging),
                new OpponentResponds("Here is your birth certificate.", OpponentExpression.Proud),
                new OpponentResponds("It says here you were born in london.", OpponentExpression.Proud),
                new OpponentResponds("Now I think it is safe to say, no planet can be born in london.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
                ArgumentLearnedFactory.Create(ArgumentType.StrawMan),
            }, 
            "born in london");
    }
}

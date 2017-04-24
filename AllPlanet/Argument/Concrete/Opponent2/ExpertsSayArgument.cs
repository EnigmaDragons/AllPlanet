using System.Collections.Generic;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete.Opponent2
{
    public static class ExpertsSayArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("You know what's kinda funny about arguing against the experts?", OpponentExpression.Challenging),
                new PlanetResponds("*What does he have now?*", PlanetExpression.Thinking),
                new OpponentResponds("Experts defined what a planet is.", OpponentExpression.Challenging),
                new OpponentResponds("As such they are the ones who judge what belongs in the category of planet.", OpponentExpression.Challenging),
                new OpponentResponds("All the experts have judged that you are not a planet!", OpponentExpression.Proud),
            },
            "experts say");
    }
}

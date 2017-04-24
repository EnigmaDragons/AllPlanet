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
            "too far from sun",
            new Statement("There is a place known as the Kuiper belt. This is the outer ring of our solar system.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "null", 9,
                    new PlanetResponds("27% of the planets in our solar system are part of this belt too!", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.Reframe, "null", 9,
                    new PlanetResponds("Actually it is known as the Edgeworth-Kuiper belt!", PlanetExpression.Challenging))),
            new Statement("This place has many larger ice bodies that are not considered planets.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "null", 9,
                    new PlanetResponds("Actually, I am 27% larger than the largest ice body among them!", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.Refuse, "null", 9,
                    new PlanetResponds("Actually, they are not ice bodies, they are \"Frozen volatiles\" known as \"ices\".", PlanetExpression.Challenging),
                    new PlanetResponds("How can a trained scientist like you miss such a distinction?", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "null", 9,
                    new PlanetResponds("That's true! And at the current rate Neptune won't be a planet in ten years.", PlanetExpression.Challenging))),
            new Statement("You are far enough away from the sun, you are in this belt.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "null", 9,
                    new PlanetResponds("I am only 29 AU from the sun. That being the case, I am not actually in the Kuiper belt.", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.AppealToEmotion, "null", 9,
                    new PlanetResponds("How far from your mother do you have to be to not be a human?", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "null", 9,
                    new PlanetResponds("Actually I am so far from your sun I am not even a part of your solar system!", PlanetExpression.Challenging),
                    new PlanetResponds("Your solar system isn't the one I would be considered a planet in anyways!", PlanetExpression.Challenging))),
            new Statement("Therefore you should not be considered a planet", OpponentExpression.Challenging)
            );
    }
}

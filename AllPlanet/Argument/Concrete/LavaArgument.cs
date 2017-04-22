using System.Collections.Generic;
using AllPlanet.Crowd;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Refute;

namespace AllPlanet.Argument
{
    public class LavaArgument
    {
        public ArgumentPoint Argument
        {
            get
            {
                return new ArgumentPoint(
                    new Statement("You are not a planet, you are a popsicle.", OpponentExpression.Challenging,
                        new RefuteOption(ArgumentType.FakeStatistic, "lava argument",
                            new PlanetResponds("22% of all planet's are popsicles, I'll have you know.", PlanetExpression.Proud), 
                            new OpponentResponds("Please! if 22% planets were popsicles, they would have been eaten.", OpponentExpression.Proud), 
                            new CrowdResponds(CrowdExpression.Boo), 
                            new PlanetResponds("*Oops I didn't think of that*", PlanetExpression.Worry))),
                    new Statement("Why? Because earth, like all planets has lava.", OpponentExpression.Challenging,
                        new RefuteOption(ArgumentType.FakeStatistic, "lava argument", //change to next argument
                            new PlanetResponds("Actually only 12% of planets have lava.", PlanetExpression.Challenging),
                            new OpponentResponds("I merely forgot about all those silly planets without lava.", OpponentExpression.Upset),
                            new CrowdResponds(CrowdExpression.Cheer))),
                    new Statement("You don't have lava, you're not hot.", OpponentExpression.Proud,
                        new RefuteOption(ArgumentType.FakeStatistic, "lava argument",
                            new PlanetResponds("100% of all hot people are not made out of lava, so I can be hot", PlanetExpression.Challenging),
                            new OpponentResponds("I'm sure you date many cute comets, like yourself.", OpponentExpression.Bored),
                            new CrowdResponds(CrowdExpression.Boo),
                            new PlanetResponds("*He just implied I'm a comet*", PlanetExpression.Worry))),
                    new Statement("Popsicles also don't have lava, therefore you are a popsicle.", OpponentExpression.Challenging,
                        new RefuteOption(ArgumentType.FakeStatistic, "lava argument", //change to tangent
                            new PlanetResponds("Only 10% of things that are not lava are popsicles, so how can you be sure.", PlanetExpression.Challenging),
                            new OpponentResponds("Well then I'm gonna prove you are in that 10%.", OpponentExpression.Challenging),
                            new CrowdResponds(CrowdExpression.NoComment))));
                            
            }
        }
    }
}

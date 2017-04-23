using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class LavaArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I will defend my existance as a planet*", PlanetExpression.Thinking),
                new OpponentResponds("You are not a planet, you are a popsicle.", OpponentExpression.Challenging),
                new OpponentResponds("Why? Because earth, like all planets has lava.", OpponentExpression.Challenging),
                new OpponentResponds("You don't have lava, you're not hot.", OpponentExpression.Proud),
                new OpponentResponds("Popsicles also don't have lava, therefore you are a popsicle.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.FakeStatistic),
                ArgumentLearnedFactory.Create(ArgumentType.Refuse),
            }, 
            "lava",
            new Statement("You are not a planet, you are a popsicle.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("lava argument"),
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", -1,
                    new PlanetResponds("22% of all planets are popsicles, I'll have you know.", PlanetExpression.Proud), 
                    new OpponentResponds("Please! If 22% planets were popsicles, they would have been eaten.", OpponentExpression.Proud), 
                    new CrowdResponds(CrowdExpression.Boo), 
                    new PlanetResponds("*Oops I didn't think of that*", PlanetExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "popsicle", -1, 
                    new PlanetResponds("That's ridiculous I am a planet, and not a popsicle.", PlanetExpression.Challenging),
                    new OpponentResponds("Simply denying the fact that you are a planet, isn't gonna work on this scientific community.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("Furthermore I can prove you are a popsicle", OpponentExpression.Challenging))),
            new Statement("Why? Because earth, like all planets has lava.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("lava argument"),
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", +3,
                    new PlanetResponds("Actually only 12% of planets have lava.", PlanetExpression.Challenging),
                    new OpponentResponds("I merely forgot about all those silly planets without lava.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Refuse, "no moon", -4, 
                    new PlanetResponds("Earth doesn't have lava.", PlanetExpression.Worried),
                    new OpponentResponds("You're not fooling anyone", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("You don't have lava, you're not hot.", OpponentExpression.Proud, GenericDiscreditResponse.Create("lava argument"),
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", -3,
                    new PlanetResponds("100% of all hot people are not made out of lava, so I can be hot", PlanetExpression.Challenging),
                    new OpponentResponds("I'm sure you date your fellow cute comets.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo),
                    new PlanetResponds("*He just implied I'm a comet*", PlanetExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "no moon", +4, 
                    new PlanetResponds("That's not quite right. I do have lava.", PlanetExpression.Challenging),
                    new OpponentResponds("What? Where?", OpponentExpression.Worried),
                    new PlanetResponds("In my core of course, next time you should do your research.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new Statement("Popsicles also don't have lava, therefore you are a popsicle.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("lava argument"),
                new RefuteOption(ArgumentType.FakeStatistic, "popsicle", 0,
                    new PlanetResponds("Only 10% of things that are not lava are popsicles, so how can you be sure.", PlanetExpression.Challenging),
                    new OpponentResponds("Well then I'm gonna prove you are in that 10%.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Refuse, "popsicle", 0,
                    new PlanetResponds("You are clearly wrong. I am not a popsicle.", PlanetExpression.Challenging),
                    new OpponentResponds("I can prove that you are one!", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))));
    }
}

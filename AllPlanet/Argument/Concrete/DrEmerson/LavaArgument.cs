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
                new PlanetResponds("*I will defend my existence as a planet*", PlanetExpression.Thinking),
                new OpponentResponds("You're not a planet. You are a popsicle.", OpponentExpression.Challenging),
                new OpponentResponds("Why? Because earth, like all planets, has lava.", OpponentExpression.Challenging),
                new OpponentResponds("You don't have lava. You're not hot.", OpponentExpression.Proud),
                new OpponentResponds("Popsicles also don't have lava. Therefore, you are a popsicle.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.FakeStatistic),
                ArgumentLearnedFactory.Create(ArgumentType.Refuse),
                /*TODO remove*/ //ArgumentLearnedFactory.Create(ArgumentType.Discredit)
            }, 
            "lava",
            new Statement("You're not a planet. You are a popsicle.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", -1,
                    new PlanetResponds("22% of all planets are popsicles, I'll have you know.", PlanetExpression.Proud), 
                    new OpponentResponds("Please! If 22% planets were popsicles, they would have been eaten.", OpponentExpression.Proud), 
                    new CrowdResponds(CrowdExpression.Boo), 
                    new PlanetResponds("*Oops, I didn't think of that*", PlanetExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "popsicle", -2, 
                    new PlanetResponds("That's ridiculous! I am a planet, not a popsicle.", PlanetExpression.Challenging),
                    new OpponentResponds("Simply denying the fact that you are a popsicle isn't gonna work on this scientific community.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("Furthermore, I can prove that you are a popsicle", OpponentExpression.Challenging))),
            new Statement("Why? Because earth, like all planets, has lava.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", +3,
                    new PlanetResponds("Actually, only 12% of planets have lava.", PlanetExpression.Challenging),
                    new OpponentResponds("I merely forgot about all those silly planets without lava.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Refuse, "no moon", -4, 
                    new PlanetResponds("Earth doesn't have lava.", PlanetExpression.Worried),
                    new OpponentResponds("You're not fooling anyone.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("You don't have lava. You're not hot.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", -3,
                    new PlanetResponds("99.87% of all hot people are not made out of lava. I am pretty damn hot.", PlanetExpression.Challenging),
                    new OpponentResponds("I'm sure you go on plenty of dates with your fellow cute comets.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo),
                    new PlanetResponds("*He just implied I'm a comet*", PlanetExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "no moon", +4, 
                    new PlanetResponds("That's not quite right. I do have lava.", PlanetExpression.Challenging),
                    new OpponentResponds("What? Where?", OpponentExpression.Worried),
                    new PlanetResponds("In my core of course, next time you should do your research.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new Statement("Popsicles also don't have lava. Therefore, you are a popsicle.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "popsicle", 0,
                    new PlanetResponds("Only 10% of things that are not lava are popsicles, so how can you be sure?", PlanetExpression.Challenging),
                    new OpponentResponds("Well then, I'm gonna prove you are in that 10%!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Refuse, "popsicle", 0,
                    new PlanetResponds("You are clearly wrong. I am not a popsicle.", PlanetExpression.Challenging),
                    new OpponentResponds("I can prove that you are one!", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))));
    }
}

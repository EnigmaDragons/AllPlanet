using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class NoMoonArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I wonder what argument is coming next*", PlanetExpression.Thinking),
                new OpponentResponds("At night when you look up in the sky there is a light.", OpponentExpression.Proud),
                new OpponentResponds("The moon showers light upon us.", OpponentExpression.Challenging),
                new OpponentResponds("But you don't have a moon!", OpponentExpression.Challenging),
                new OpponentResponds("Saturn has a whole belt of moons.", OpponentExpression.Bored),
                new OpponentResponds("Therefore, you are not a true planet.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.AgreeAndAmplify),
                ArgumentLearnedFactory.Create(ArgumentType.AppealToEmotion),
            }, 
            "no moon", 
            new Statement("At night when you look up in the sky there is a light.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.AppealToEmotion, "born in london", +2,
                    new PlanetResponds("Not all planets have that light. Just imagine complete darkness and how scary that must be!", PlanetExpression.Challenging),
                    new PlanetResponds("That is how I am feeling when I think of what might happen if these crazy scientists win!", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("That seems hardly the point!", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "born in london", -2, 
                    new PlanetResponds("No it's nighttime, it's clearly dark not light.", PlanetExpression.Challenging),
                    new OpponentResponds("I understand it might be hard for you to imagine.", OpponentExpression.Challenging),
                    new OpponentResponds("Having no moon, you must not have realized the moon reflects light from the sun.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Sympathy))),
            new Statement("The moon showers light upon us.", OpponentExpression.Challenging, 
                new RefuteOption(ArgumentType.FakeStatistic, "born in london", -1,
                    new PlanetResponds("Well for 1 out of every 29 days it doesn't. It's a new moon.", PlanetExpression.Challenging),
                    new OpponentResponds("Still, at least we have a moon!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Refuse, "born in london", 0, 
                    new PlanetResponds("Well, technically speaking, it doesn't shower light on all of us.", PlanetExpression.Challenging),
                    new OpponentResponds("And, technically, you are being pedantic.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new PlanetResponds("*That turned around quickly*", PlanetExpression.Worried))),
            new Statement("But you don't have a moon!", OpponentExpression.Challenging, 
                new RefuteOption(ArgumentType.AppealToEmotion, "born in london", +1,
                    new PlanetResponds("I'm just a lonely planet on a lonely road with no moon to keep me company. Alone!", PlanetExpression.Sad),
                    new PlanetResponds("Now these scientists are saying that just because I don't have one, that somehow makes me not a planet.", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("Imagine how the real planets must feel being compared to a comet like him.", OpponentExpression.Bored)),
                new RefuteOption(ArgumentType.FakeStatistic, "born in london", 0,
                    new PlanetResponds("15% of planets don't have moons.", PlanetExpression.Challenging),
                    new OpponentResponds("Then those aren't true planets. They will be on this podium next!", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Saturn has a whole belt of moons.", OpponentExpression.Bored,
                new RefuteOption(ArgumentType.AppealToEmotion, "moons are not good", 0,
                    new PlanetResponds("And I don't even have a single one! Do you see how unlucky that is? Some planets get all the moons.", PlanetExpression.Challenging),
                    new OpponentResponds("You're lucky to not have so many moons! You don't know the hardships of having moons.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.FakeStatistic, "born in london", 0, 
                    new PlanetResponds("25% of experts say that Saturn doesn't have a whole belt of moons.", PlanetExpression.Challenging),
                    new OpponentResponds("What are the names of these so called experts?", OpponentExpression.Challenging),
                    new PlanetResponds("...", PlanetExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Therefore, you are not a true planet.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AgreeAndAmplify, "born in london", -1,
                    new PlanetResponds("Oh yes. Without a moon I'm hardly even a comet. In fact, I must just be some rubble coming off a meteor because I don't have a moon.", PlanetExpression.Challenging),
                    new OpponentResponds("You will feel like rubble once I'm finished with this argument.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Refuse, "born in london", -1, 
                    new PlanetResponds("That's nonsense! I am definitely a real planet.", PlanetExpression.Challenging),
                    new OpponentResponds("It sounds like you have no real objections. I will carry on.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Cheer))));
    }
}

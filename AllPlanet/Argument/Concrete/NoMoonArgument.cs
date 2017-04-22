using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete
{
    public class NoMoonArgument
    {
        public ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I wonder what argument is coming next*", PlanetExpression.Thinking),
                new OpponentResponds("At night when you look up in the sky there is a light.", OpponentExpression.Proud),
                new OpponentResponds("The moon showers light upon us.", OpponentExpression.Challenging),
                new OpponentResponds("But you don't have a moon!", OpponentExpression.Challenging),
                new OpponentResponds("Saturn has a whole belt of moons.", OpponentExpression.Bored),
                new OpponentResponds("Therefore you are not a true planet.", OpponentExpression.Challenging),
                new ArgumentLearned(ArgumentType.AgreeAndAmplify, "This argument does just solve some situations. It can solve your plumbing, get you a date, and save the world!"),
                new ArgumentLearned(ArgumentType.AppealToEmotion, "Example here"),
            }, 
            "no moon", 
            new Statement("At night when you look up in the sky there is a light.", OpponentExpression.Proud, GenericDiscreditResponse.Create("no moon"),
                new RefuteOption(ArgumentType.AppealToEmotion, "next", 
                    new PlanetResponds("Not all planet's have that light, just imagine complete darkness and how scary that must be!", PlanetExpression.Challenging),
                    new PlanetResponds("That is how I am feeling when I think of what might happen if these crazy scientists win!", PlanetExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment), //possible add crowd expression for this
                    new OpponentResponds("That seems hardly the point!", OpponentExpression.Worried))),
            new Statement("The moon showers light upon us.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("no moon"), 
                new RefuteOption(ArgumentType.FakeStatistic, "next", 
                    new PlanetResponds("Well for 1 out of every 29 days it doesn't, it's a new moon.", PlanetExpression.Challenging),
                    new OpponentResponds("But we still have a moon!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("But you don't have a moon!", OpponentExpression.Challenging, GenericDiscreditResponse.Create("no moon"), 
                new RefuteOption(ArgumentType.AppealToEmotion, "next",
                    new PlanetResponds("I'm a lonely planet with no moon to keep me company.", PlanetExpression.Worried), //possible add sad planet
                    new PlanetResponds("And now these scientists are saying that just because I don't have one, that somehow makes me not a planet.", PlanetExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment),
                    new OpponentResponds("Imagine how the real planets must feel being compared to a comet like him.", OpponentExpression.Bored)),
                new RefuteOption(ArgumentType.FakeStatistic, "next", 
                    new PlanetResponds("15% of planets don't have moons.", PlanetExpression.Challenging),
                    new OpponentResponds("Then those arn't true planets and they will be on the podium next", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Saturn has a whole belt of moons.", OpponentExpression.Bored, GenericDiscreditResponse.Create("no moon"),
                new RefuteOption(ArgumentType.AppealToEmotion, "moons are not good", 
                    new PlanetResponds("And I don't even have one! Do you see how unlucky that is when some planets get all the moons?", PlanetExpression.Challenging),
                    new OpponentResponds("Your lucky to not have so many moons! You don't know the hardships of having moons.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Therefore you are not a true planet.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("no moon"),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "next",
                    new PlanetResponds("Oh yes. I mean without a moon I'm hardly even a comet. In fact I must just be some rubble coming off a meteor because I don't have a moon.", PlanetExpression.Challenging),
                    new OpponentResponds("You will feel like rubble once I'm finished with this argument.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo))));
    }
}

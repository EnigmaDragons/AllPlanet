using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete
{
    public static class MoonsAreNotGoodArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I have never had a moon.*", PlanetExpression.Thinking),
                new OpponentResponds("Did you know saturn has meteor showers all the time.", OpponentExpression.Challenging),
                new OpponentResponds("Why because all those damn moons and astroids it has!", OpponentExpression.Worried),
                new OpponentResponds("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
            }, 
            "moons are not good", 
            new Statement("Did you know saturn has meteor showers all the time?", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.FakeStatistic, "emerson rebutal", -2,
                    new PlanetResponds("Well only 50% percent of the time.", PlanetExpression.Challenging),
                    new OpponentResponds("So you would only be getting killed 50% of the time.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Reframe, "emerson rebutal", +2,
                    new PlanetResponds("It must be nice. Like when you walk outside and there is a pleasent drizzle coming down on a hot day.", PlanetExpression.Proud),
                    new OpponentResponds("That's not what it's like at all", OpponentExpression.Worried),
                    new PlanetResponds("How would you know? Are you a planet?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "emerson rebutal", -2,
                    new PlanetResponds("Oh yes. All the frickin time. Right now. An hour ago. You would just be walking along saying hi to the meteors falling around you.", PlanetExpression.Challenging),
                    new OpponentResponds("Well certainly often enough", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Why? because all those damn moons and astroids it has!", OpponentExpression.Worried, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.Reframe, "emerson rebutal", -1, 
                    new PlanetResponds("It has so many moons and astroids to protect it from outer comets and astroids.", PlanetExpression.Challenging),
                    new OpponentResponds("I doubt it gets bombarded by comets very often.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.AppealToEmotion, "emerson rebutal", -2,
                    new PlanetResponds("Arn't you guys, basically trying to do the same?", PlanetExpression.Worried),
                    new OpponentResponds("We are merely acedemics who wish to know the truth.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))));
    }
}

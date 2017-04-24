using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class MoonsAreNotGoodArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I have never had a moon.*", PlanetExpression.Thinking),
                new OpponentResponds("Did you know Saturn has meteor showers all the time?", OpponentExpression.Challenging),
                new OpponentResponds("Why? Because of all those damn moons and asteroids it has!", OpponentExpression.Worried),
                new OpponentResponds("Given how small you are, a meteor shower would surely kill you.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
            }, 
            "moons are not good", 
            new Statement("Did you know Saturn has meteor showers all the time?", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "born in london", -2,
                    new PlanetResponds("Well, only 50% percent of the time.", PlanetExpression.Challenging),
                    new OpponentResponds("So you would only be getting killed 50% of the time.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Reframe, "born in london", +2,
                    new PlanetResponds("It must be nice. Like when you walk outside and there is a pleasent drizzle coming down on a hot day.", PlanetExpression.Proud),
                    new OpponentResponds("That's not what it's like at all", OpponentExpression.Worried),
                    new PlanetResponds("How would you know? Are you a planet?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "born in london", -2,
                    new PlanetResponds("Oh yes. All the frickin' time! Right now. An hour ago. You would just be walking along saying \"Hi\" to the meteors falling around you.", PlanetExpression.Challenging),
                    new OpponentResponds("Well, certainly often enough.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Why? Because of all those damn moons and asteroids it has!", OpponentExpression.Worried,
                //new RefuteOption(ArgumentType.Reframe, "born in london", -1, 
                    //new PlanetResponds("It has so many moons and asteroids to protect it from outer comets and asteroids.", PlanetExpression.Challenging),
                    //new OpponentResponds("I doubt it gets bombarded by comets very often.", OpponentExpression.Bored),
                    //new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Refuse, "born in london", -2, 
                    new PlanetResponds("It doesn't have moons and asteroids.", PlanetExpression.Challenging),
                    new OpponentResponds("You are wrong.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo),
                    new PlanetResponds("*How could I have been so stupid?*", PlanetExpression.Worried),
                new RefuteOption(ArgumentType.Reframe, "born in london", +2,
                    new PlanetResponds("Damn moons? I don't even know what a damn moon is!", PlanetExpression.Thinking),
                    new PlanetResponds("But that might be why it always has meteor showers, come to think of it.", PlanetExpression.Thinking),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("I didn't mean it literally...", OpponentExpression.Worried),
            new Statement("Given how small you are, a meteor shower would surely kill you.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AppealToEmotion, "born in london", 0,
                    new PlanetResponds("Aren't you guys basically trying to do the same?", PlanetExpression.Worried),
                    new OpponentResponds("We are merely academics who wish to know the truth.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Refuse, "born in london", +1, 
                    new PlanetResponds("I could easily survive meteor showers.", PlanetExpression.Proud),
                    new OpponentResponds("Not if the meteors are the same size as you.", OpponentExpression.Challenging),
                    new PlanetResponds("That...would be a planet shower.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)))))));
    }
}

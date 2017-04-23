﻿using System.Collections.Generic;
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
                new OpponentResponds("Did you know saturn has meteor showers all the time.", OpponentExpression.Challenging),
                new OpponentResponds("Why because all those damn moons and astroids it has!", OpponentExpression.Worried),
                new OpponentResponds("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
            }, 
            "moons are not good", 
            new Statement("Did you know saturn has meteor showers all the time?", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.FakeStatistic, "born in london", -2,
                    new PlanetResponds("Well only 50% percent of the time.", PlanetExpression.Challenging),
                    new OpponentResponds("So you would only be getting killed 50% of the time.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Reframe, "born in london", +2,
                    new PlanetResponds("It must be nice. Like when you walk outside and there is a pleasent drizzle coming down on a hot day.", PlanetExpression.Proud),
                    new OpponentResponds("That's not what it's like at all", OpponentExpression.Worried),
                    new PlanetResponds("How would you know? Are you a planet?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "born in london", -2,
                    new PlanetResponds("Oh yes. All the frickin time. Right now. An hour ago. You would just be walking along saying hi to the meteors falling around you.", PlanetExpression.Challenging),
                    new OpponentResponds("Well certainly often enough", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Why? because all those damn moons and astroids it has!", OpponentExpression.Worried, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.Reframe, "born in london", -1, 
                    new PlanetResponds("It has so many moons and astroids to protect it from outer comets and astroids.", PlanetExpression.Challenging),
                    new OpponentResponds("I doubt it gets bombarded by comets very often.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Refuse, "born in london", 0, 
                    new PlanetResponds("It doesn't have moon and astroids.", PlanetExpression.Challenging),
                    new OpponentResponds("You are wrong.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo),
                    new PlanetResponds("*How could I have been so stupid*", PlanetExpression.Worried))),
            new Statement("Given how small you are a meteor shower would surely kill you.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("moons are not good"),
                new RefuteOption(ArgumentType.AppealToEmotion, "born in london", -2,
                    new PlanetResponds("Arn't you guys, basically trying to do the same?", PlanetExpression.Worried),
                    new OpponentResponds("We are merely acedemics who wish to know the truth.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Refuse, "born in london", +2, 
                    new PlanetResponds("I could easily survive meteor showers.", PlanetExpression.Proud),
                    new OpponentResponds("Not if the meteors are the size of you.", OpponentExpression.Challenging),
                    new PlanetResponds("Please! I'm fast enough I could dodge a meteor that size.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))));
    }
}

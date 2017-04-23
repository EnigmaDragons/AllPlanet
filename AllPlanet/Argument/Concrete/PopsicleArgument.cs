﻿using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete
{
    public class PopsicleArgument
    {
        public ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*This is ridiculous, I'm clearly not a popsicle*", PlanetExpression.Thinking),
                new OpponentResponds("It's simple really, popsicles have ice.", OpponentExpression.Proud),
                new OpponentResponds("Popsicles are small.", OpponentExpression.Challenging),
                new OpponentResponds("You both have ice, and are small", OpponentExpression.Proud),
                new ArgumentLearned(ArgumentType.AgreeAndAmplify, "This argument does just solve some situations. It can solve your plumbing, get you a date, and save the world!"),
            }, 
            "popsicle", 
            new Statement("It's simple really, popsicles have ice.", OpponentExpression.Proud, GenericDiscreditResponse.Create("popsicle"),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "no moon", -1,
                    new PlanetResponds("Your right! It's so simple a 2 year old could understand it!", PlanetExpression.Proud),
                    new OpponentResponds("Thank you, now would you let me finish!", OpponentExpression.Worried))),
            new Statement("Popsicles are small.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("popsicle"), 
                new RefuteOption(ArgumentType.FakeStatistic, "no moon", -1,
                    new PlanetResponds("Actually 1% of popsicles are made to be large.", PlanetExpression.Challenging),
                    new OpponentResponds("And 1% of comets love to waste our time.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "no moon", -2,
                    new PlanetResponds("Small? They are tiny the smallest!", PlanetExpression.Proud),
                    new OpponentResponds("Just like your brain.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("You both have ice, and are small", OpponentExpression.Proud, GenericDiscreditResponse.Create("popsicle"),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "no moon", +2,
                    new PlanetResponds("You are right! I mean I taste like a popsicle.", PlanetExpression.Challenging),
                    new OpponentResponds("That's not what I meant--", OpponentExpression.Worried),
                    new PlanetResponds("I betcha they would sell me in an ice cream truck on accident!", PlanetExpression.Proud),
                    new OpponentResponds("Okay you're not exactly a popsicle--", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("Fine but back to my original argument", OpponentExpression.Worried))));
    }
}

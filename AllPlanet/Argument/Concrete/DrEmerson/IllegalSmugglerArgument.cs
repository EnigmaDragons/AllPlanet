﻿using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class IllegalSmugglerArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*What else is he going to bring up?*", PlanetExpression.Thinking),
                new OpponentResponds("\"Planet\" is an honorable title. But you are not an honorable planet, are you?", OpponentExpression.Challenging),
                new OpponentResponds("You have been involved in smuggling illegal weapons to warmongers.", OpponentExpression.Challenging),
                new OpponentResponds("We have caught and punished the smugglers, but we never judged you for your involvement in holding onto those weapons.", OpponentExpression.Challenging),
                new OpponentResponds("Ladies and gentlemen, I plead with you! Don't let some lawbreaking entity tarnish what a planet is.", OpponentExpression.Worried),
                ArgumentLearnedFactory.Create(ArgumentType.Discredit),
                ArgumentLearnedFactory.Create(ArgumentType.AdHominem),
            },
            "illegal smuggling",
            new Statement("\"Planet\" is an honorable title. But you are not an honorable planet, are you?", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AgreeAndAmplify, "emerson rebutal", -2,
                    new PlanetResponds("Oh yes! People would kill for this title.", PlanetExpression.Challenging),
                    new PlanetResponds("I mean planet's are murdering each other just so they can be the only one in a solar system with this sweet title.", PlanetExpression.Challenging),
                    new OpponentResponds("Well if the title doesn't matter, why do you want it so much?", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AppealToEmotion, "emerson rebutal", +2,
                    new PlanetResponds("That's ridiculous. Honorable titles are earned.", PlanetExpression.Challenging),
                    new PlanetResponds("This \"title\", is more like when you tell a person, that they are human", PlanetExpression.Challenging),
                    new PlanetResponds("Imagine debating in front of scientific board if you are human or not.", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy)),
                new RefuteOption(ArgumentType.AdHominem, "legit scientist", +3,
                    new PlanetResponds("Being a scientist is an honorable title.", PlanetExpression.Challenging),
                    new PlanetResponds("But the way you throw around loose facts, and made up accusations. You don't deserve your title.", PlanetExpression.Challenging),
                    new OpponentResponds("My facts are not made up! I Shall prove I'm a legitimate scientist.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("You have been involved in smuggling illegal weapons to warmongers.", OpponentExpression.Challenging,
               new RefuteOption(ArgumentType.Reframe, "emerson rebutal", +4,
                    new PlanetResponds("That's not quite true. I was smuggling those weapons to rebels.", PlanetExpression.Challenging),
                    new PlanetResponds("Within the oppressed government of Rakkas, people were being executed left and right.", PlanetExpression.Challenging),
                    new PlanetResponds("I supplied the rebels with weapons to fight back against this tyrant regime!", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer)),
               new RefuteOption(ArgumentType.Illegitimize, "emerson rebutal", +1,
                   new PlanetResponds("Involved? Are you going to say that the boxes used to carry illegal produce, were involved?", PlanetExpression.Challenging),
                   new PlanetResponds("Maybe those boxes should be punished and not considered boxes anymore too!", PlanetExpression.Challenging),
                   new OpponentResponds("Boxes aren't sentient beings", OpponentExpression.Worried),
                   new CrowdResponds(CrowdExpression.NoComment)),
               //Should this be in here, it's almost very meta because planets aren't sentient beings either?
               new RefuteOption(ArgumentType.FakeStatistic, "emerson rebutal", +2,
                   new PlanetResponds("Excuse me, it appears 2 other planet's in this solor system alone have been involved in smuggling illegal weapons.", PlanetExpression.Challenging),
                   new PlanetResponds("Are you claiming they also are not planets?", PlanetExpression.Challenging),
                   new OpponentResponds("I didn't know this!", OpponentExpression.Worried),
                   new CrowdResponds(CrowdExpression.Boo))),
            new Statement("We caught and punished those smugglers, but we never judged you for your involvement in holding onto those weapons.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AppealToEmotion, "emerson rebutal", -2,
                    new PlanetResponds("I was forced into it. My family was threatened.", PlanetExpression.Sad),
                    new PlanetResponds("They were going to kill my family, what would you have done?", PlanetExpression.Sad),
                    new OpponentResponds("You still helped terrorists you fiend.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "emerson rebutal", +2,
                    new PlanetResponds("Those smugglers would never have been caught if it weren't for me.", PlanetExpression.Proud),
                    new PlanetResponds("I worked with law enforcment to catch them, I staged as a convenient smuggling planet.", PlanetExpression.Proud),
                    new PlanetResponds("We caught them red-handed.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("I didn't know.", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.AdHominem, "legit scientist", 0, 
                    new PlanetResponds("I don't think we have judged you, for your terrible science.", PlanetExpression.Challenging),
                    new PlanetResponds("When did we hire monkeys to do our science? Am I Right?", PlanetExpression.Challenging),
                    new OpponentResponds("Please I can prove I'm a legitimate scientist.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Ladies and gentlemen, I plead with you! Don't let some lawbreaking entity tarish what a planet is.", OpponentExpression.Worried,
                new RefuteOption(ArgumentType.AdHominem, "legit scientist", +1,
                    new PlanetResponds("I plead with the audience, don't let some hooligan, tarnish what a scientist is.", PlanetExpression.Challenging),
                    new OpponentResponds("How dare you! I shall show you why I'm a legitimate scientist.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Illegitimize, "emerson rebutal", +2,
                    new PlanetResponds("Oh, look Timmy just littere on the floor, he's a lawbreaking entity.", PlanetExpression.Challenging),
                    new PlanetResponds("Welp let's not let poor Timmy tarnish what  human is. Sorry Timmy you are no longer a human.", PlanetExpression.Proud),
                    new OpponentResponds("Littering is not even close to...", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))));
    }
}

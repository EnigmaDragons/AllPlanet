using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class FakeCertificateArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*Can he really prove this is my birth certificate?*", PlanetExpression.Thinking),
                new OpponentResponds("I talked to Dr.Tomas, he helped with your birth.", OpponentExpression.Proud),
                new OpponentResponds("Dr.Tomas says he fucking hated it! He tries to forget your face by playing Doom.", OpponentExpression.Challenging),
                new OpponentResponds("He comfirmed who you were.", OpponentExpression.Proud),
                new OpponentResponds("I also looked up how many people in London have ever been called Stilles 33, and it's only you.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Discredit),
            }, 
            "fake certificate",
            new Statement("I talked to Dr.Tomas, he helped with your birth.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.Refuse, "illegal smuggling", -3, 
                    new PlanetResponds("No, it was definitely a different doctor.", PlanetExpression.Thinking),
                    new OpponentResponds("But he can confirm it was you.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "illegal smuggling", -4,
                    new PlanetResponds("He didn't just help with the birth, he practically gave the birth.", PlanetExpression.Challenging),
                    new OpponentResponds("Then he would especially remember your face.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("Dr.Tomas says he fucking hated it! He tries to forget your face by playing Doom.", OpponentExpression.Challenging, 
                new RefuteOption(ArgumentType.Discredit, "illegal smuggling", +4,
                    new PlanetResponds("How is it, that Dr.Tomas who has been forgetting my face...", PlanetExpression.Challenging),
                    new PlanetResponds("Can suddenly confirm who I am? Especially after all these years.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("Well, maybe he didn't forget.", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.AppealToEmotion, "illegal smuggling", +1, 
                    new PlanetResponds("And you pressed this traumatized person for answers?", PlanetExpression.Sad),
                    new PlanetResponds("How can you be so heartless by forcing a man to try and remember something so painful?", PlanetExpression.Sad),
                    new PlanetResponds("He probably just told you what you wanted to hear, so you would leave him alone.", PlanetExpression.Sad),
                    new OpponentResponds("No, he was more than willing to cooperate, I swear.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Refuse, "illegal smuggling", +3, 
                    new PlanetResponds("That's clearly a lie. Computers hadn't even been invented when I was born.", PlanetExpression.Challenging),
                    new PlanetResponds("How the hell could he be playing Doom without a computer?", PlanetExpression.Challenging),
                    new OpponentResponds("Doom can run on anything, even a rock!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new Statement("He comfirmed who you were.", OpponentExpression.Proud, 
                new RefuteOption(ArgumentType.Discredit, "illegal smuggling", +4,
                    new PlanetResponds("How is it, that Dr.Tomas who has been forgetting my face...", PlanetExpression.Challenging),
                    new PlanetResponds("Can suddenly confirm who I am? Especially after all these years.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("Well, maybe he didn't forget.", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Reframe, "illegal smuggling", -1,
                    new PlanetResponds("Then he knows, without a doubt, that I am indeed a planet.", PlanetExpression.Proud),
                    new OpponentResponds("We don't know his opinion on whether or not you are a planet", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.FakeStatistic, "illegal smuggling", -3, 
                    new PlanetResponds("Doctors only remember 11% of their patients.", PlanetExpression.Challenging),
                    new OpponentResponds("I think you are a special case.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("I also looked up how many people in London have ever been called Stilles 33, and it's only you.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.Illegitimize, "illegal smuggling", +1, 
                    // TODO Rewrite
                    new PlanetResponds("You ran a Google search, who are people named Stilles 33, born in London.", PlanetExpression.Challenging),
                    // TODO Rewrite
                    new PlanetResponds("Let me guess you went in and stared at great big books full of names of people born in London.", PlanetExpression.Challenging),
                    new OpponentResponds("I'm a scientist who gets paid to do studies.", OpponentExpression.Proud),
                    new OpponentResponds("Of course I know how to research.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.FakeStatistic, "illegal smuggling", -2,
                    new PlanetResponds("Did you know that only 34% of people born around the time I was born had their names recorded?", PlanetExpression.Challenging),
                    new PlanetResponds("You stopped your hunt early. There could have easily been many more.", PlanetExpression.Challenging),
                    new OpponentResponds("Well even so, Dr.Tomas still proves I'm right.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo))));
    }
}

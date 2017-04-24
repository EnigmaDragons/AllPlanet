﻿using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class BornInLondonArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*I bet he is out of good arguments*", PlanetExpression.Thinking),
                new OpponentResponds("I have with me some irrefutable evidence that you are not a planet.", OpponentExpression.Challenging),
                new OpponentResponds("Here is your birth certificate.", OpponentExpression.Proud),
                new OpponentResponds("It says here you were born in London.", OpponentExpression.Proud),
                new OpponentResponds("Now I think it is safe to say, no planet can be born in London.", OpponentExpression.Challenging),
                ArgumentLearnedFactory.Create(ArgumentType.Reframe),
                ArgumentLearnedFactory.Create(ArgumentType.StrawMan),
            }, 
            "born in london", 
            new Statement("I have with me some irrefutable evidence that you are not a planet.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("born in london"),
                new RefuteOption(ArgumentType.Refuse, "emerson rebutal", -3, 
                    new PlanetResponds("It is refutable, because I am refuting it right now!", PlanetExpression.Challenging),
                    new OpponentResponds("No. You are just making a fool of yourself.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "emerson rebutal", -1, 
                    new PlanetResponds("Oh it's irrefutable, no one could ever defeat it in a million years!", PlanetExpression.Challenging),
                    new PlanetResponds("It's the holy evidence, thou shall not refute.", PlanetExpression.Sad),
                    new PlanetResponds("All science is based around this proof.", PlanetExpression.Challenging),
                    new OpponentResponds("Well I don't hear you refuting it!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Here is your birth certificate.", OpponentExpression.Proud, GenericDiscreditResponse.Create("born in london"),
                new RefuteOption(ArgumentType.Reframe, "fake certificate", 2, 
                    new PlanetResponds("You misread that document.", PlanetExpression.Challenging),
                    new PlanetResponds("That is the diploma for my Master's in Astronomy at Oxford University.", PlanetExpression.Proud),
                    new PlanetResponds("I'm so glad you found it for me.", PlanetExpression.Challenging),
                    new OpponentResponds("I swear that's not what this is!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.StrawMan, "fake certificate", 3, 
                    new PlanetResponds("Now you're buying random birth certificates off of craigslist with the same name as me.", PlanetExpression.Challenging),
                    new OpponentResponds("Your name is not that common!", OpponentExpression.Worried),
                    new PlanetResponds("I bet you spent hours pouring over Google finding birth certificate forgers.", PlanetExpression.Challenging),
                    new PlanetResponds("I'm not sure which is more amazing, the fact that you found a fake, or the fact that you wasted money on it.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("I will prove this is yours!", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "fake certificate", 0, 
                    new PlanetResponds("No it's not!", PlanetExpression.Challenging),
                    new PlanetResponds("That's not mine. I have mine.", PlanetExpression.Challenging),
                    new OpponentResponds("I can prove it's yours.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("It says here you were born in London.", OpponentExpression.Proud, GenericDiscreditResponse.Create("born in london"),
                new RefuteOption(ArgumentType.Refuse, "emerson rebutal", -3, 
                    new PlanetResponds("No it clearly says I was born in space.", PlanetExpression.Challenging),
                    new OpponentResponds("Are you questioning a great scientist's ability to read?", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.StrawMan, "emerson rebutal", -1, 
                    new PlanetResponds("And it says on Wikipedia I was born in Pittsburg.", PlanetExpression.Challenging),
                    new PlanetResponds("I read a tabloid that said I'm from South Africa.", PlanetExpression.Challenging),
                    new PlanetResponds("It's hard to keep track of all these crazy places I come from", PlanetExpression.Thinking),
                    new OpponentResponds("But this is your birth certificate.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Now I think it is safe to say, no planet can be born in london.", OpponentExpression.Challenging, GenericDiscreditResponse.Create("born in london"),
                new RefuteOption(ArgumentType.AppealToEmotion, "emerson rebutal", 2, 
                    new PlanetResponds("My family was a poor family, barely getting by.", PlanetExpression.Sad),
                    new PlanetResponds("And when I turned out to be a whole planet, they didn't know how they were going to be able to take care of me.", PlanetExpression.Sad),
                    new PlanetResponds("I couldn't bear to see them starve themselves, so in the middle of the night I left them to go orbit the sun.", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy)),
                new RefuteOption(ArgumentType.FakeStatistic, "emerson rebutal", -1,
                    new PlanetResponds("Actually 100% of the planets born on earth, have been born in london.", PlanetExpression.Challenging),
                    new PlanetResponds("I think that's pretty conclusive. It would all together be reasonable to say that planet's are born in london.", PlanetExpression.Proud),
                    new OpponentResponds("You're the only one claiming planet's are born on earth at all!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "emerson rebutal", 3, 
                    new PlanetResponds("Why? Because good things don't happen to London?", PlanetExpression.Challenging),
                    new PlanetResponds("Are you saying that nothing great comes out of London?", PlanetExpression.Challenging),
                    new PlanetResponds("What do you have against London? Why do you hate them so much?", PlanetExpression.Sad),
                    new OpponentResponds("No I don't hate London, that's not what I am saying!", OpponentExpression.Worried),
                    new PlanetResponds("So great things do come from London?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))));
    }
}

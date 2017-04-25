using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete.DrEmerson
{
    public static class LegitScientistArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new PlanetResponds("*The fact that he has to argue his a legit scientist makes him look bad*", PlanetExpression.Thinking),
                new OpponentResponds("I am a legitimate scientist because of all these creditentials I have.", OpponentExpression.Proud),
                new OpponentResponds("I also discovered element 199 Rexium.", OpponentExpression.Challenging),
                new OpponentResponds("I have given millions of speeches, in every scientific community.", OpponentExpression.Challenging),
                new OpponentResponds("No one can dispute my legitimacy.", OpponentExpression.Proud),
                ArgumentLearnedFactory.Create(ArgumentType.AppealToAuthority),
            }, 
            "legit scientist",
            new Statement("I am a legitimate scientist because of all these creditentials I have.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.AppealToEmotion, "emerson rebutal", +1, 
                    new PlanetResponds("Did you know I tried to get a Masters.", PlanetExpression.Sad),
                    new PlanetResponds("After making it through the entire course I came in and they refused to give me my Masters, because I was a planet.", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy)),
                new RefuteOption(ArgumentType.AppealToAuthority, "emerson rebutal", -2, 
                    new PlanetResponds("Did you know Thomas Edison dropped out of school?", PlanetExpression.Challenging),
                    new PlanetResponds("It was a waste of his time and money. Or maybe you have heard about the wright brothers.", PlanetExpression.Challenging),
                    new PlanetResponds("Bill gates was successful don't you think. So tell me again how credentials make you a legitimate scientist?", PlanetExpression.Challenging),
                    new OpponentResponds("Ladies and Gentleman, he is attacking our credentials. He thinks all your credentials are bad!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Illegitimize, "emerson rebutal", -2, 
                    new PlanetResponds("Oh yeah I bet you got a credential last week!", PlanetExpression.Challenging),
                    new PlanetResponds("Probably paid a guy in india to get it for you.", PlanetExpression.Challenging),
                    new OpponentResponds("I spent a long time earning these.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("I also discovered element 199 Rexium.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AppealToAuthority, "emerson rebutal", +2, 
                    new PlanetResponds("The great scientist Raymond Oxford, calls this element a hoax.", PlanetExpression.Challenging),
                    new PlanetResponds("He says that you invented the idea just to grab fame.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment),
                    new OpponentResponds("No, it's real, I have made it I swear!", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Illegitimize, "emerson rebutal", +1, 
                    new PlanetResponds("Well I just discovered element 200 Fluffium.", PlanetExpression.Challenging),
                    new PlanetResponds("But don't worry, you can invent 201 Plagium.", PlanetExpression.Challenging),
                    new OpponentResponds("Do you have published papers on your element.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption("emerson rebutal", "planet made from 2", "planet made from", ArgumentType.Refuse, "emerson rebutal", +2, 
                    new PlanetResponds("You bastard! You didn't discover that element.", PlanetExpression.Sad),
                    new PlanetResponds("I discovered that. It's found on my planet", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment),
                    new OpponentResponds("You may have had it on your planet, but I actually studied it.", OpponentExpression.Worried))),
            new Statement("I have given millions of speeches, in every scientific community.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AgreeAndAmplify, "emerson rebutal", +1,
                    new PlanetResponds("Millions! I mean every single scientist has gotten a personal speech from him.", PlanetExpression.Proud),
                    new PlanetResponds("He has given them all. That speech you attended last week was secretly him all along!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("You're exaggerating my position.", OpponentExpression.Worried)),
                new RefuteOption("emerson rebutal", "unite 2", "unite", ArgumentType.AdHominem, "emerson rebutal", +1, 
                    new PlanetResponds("You have been allowed to poison the minds of the entire scientific community?", PlanetExpression.Challenging),
                    new PlanetResponds("I feel sorry, that villains like you are able to assert your dominance.", PlanetExpression.Sad),
                    new OpponentResponds("I give the highest quality talks.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("No one can dispute my legitimacy.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.AppealToAuthority, "emerson rebutal", +2, 
                    new PlanetResponds("Actually the famous scientist Raymond Oxford was questioning your legitmacy just last week.", PlanetExpression.Thinking),
                    new PlanetResponds("He wrote, and I quote \"The theories you hold have long been disproven and you are clearly incapable of staying up to date.\"", PlanetExpression.Challenging),
                    new OpponentResponds("Raymond has constantly been slandering my name, he should not be trusted.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "emerson rebutal", +1, 
                    new PlanetResponds("You heard it here first. No one can dispute the great and powerful Dr.Emerson!", PlanetExpression.Challenging),
                    new PlanetResponds("He is the scientist to end all scientists, there can be no shortcomings in any of his theories.", PlanetExpression.Challenging),
                    new OpponentResponds("I just said you can't argue my legitimacy!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))));
    }
}

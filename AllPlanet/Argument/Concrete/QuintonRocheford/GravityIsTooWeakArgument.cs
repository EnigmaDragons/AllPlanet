using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Player;

namespace AllPlanet.Argument.Concrete
{
    public static class GravityIsTooWeakArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("I don't think you understand the gravity of the situation.", OpponentExpression.Proud),
                new PlanetResponds("*What does that mean?*", PlanetExpression.Thinking),
                new OpponentResponds("I am able to stand on this podium without so much as a pull from your gravity. You're gravity is practically non-existent!", OpponentExpression.Proud),
                new OpponentResponds("That's the reason you don't have a moon.", OpponentExpression.Challenging),
                new OpponentResponds("You're gravity is practically non-existent.", OpponentExpression.Proud),
                new OpponentResponds("Planet's are formed by gravity pulling things together.", OpponentExpression.Challenging),
                new OpponentResponds("With no gravity like that, you are not a planet.", OpponentExpression.Challenging),
                new CrowdResponds(CrowdExpression.NoComment),
                ArgumentLearnedFactory.Create(ArgumentType.AppealToAuthority),
            }, 
            "gravity is too weak",
            new Statement("I am able to stand on this podium without so much as a pull from your gravity. You're gravity is practically non-existent!", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.AppealToEmotion, "too small", +1, 
                    new PlanetResponds("Do you know what's like to not have gravity?", PlanetExpression.Sad),
                    new PlanetResponds("It's like when you are a single parent, and you have to miss your son's ball game because you need to pay rent.", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("I don't even understand how that relates.", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "too small", 0,
                    new PlanetResponds("Actually, I just temporarily turned my gravity off.", PlanetExpression.Challenging),
                    new PlanetResponds("I didn't want to harm any of the audience.", PlanetExpression.Challenging),
                    new OpponentResponds("That's not how gravity works!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "too small", +1, 
                    new PlanetResponds("It makes me one of the most scientifically interesting planets.", PlanetExpression.Proud),
                    new PlanetResponds("It will be a new era of space flight when someone figures out how I nullify gravity.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("We don't need to label you as a planet to study that.", OpponentExpression.Proud))),
            new Statement("That's the reason you don't have a moon.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.Refuse, "too small", 0,
                    new PlanetResponds("Actually now I do have a moon, just picked one up you know.", PlanetExpression.Challenging),
                    new OpponentResponds("AND WHERE THE HELL IS THIS MOON!", OpponentExpression.Proud),
                    new PlanetResponds("Roughly 4,200 million kilometers from here.", PlanetExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AppealToEmotion, "too small", +2, 
                    new PlanetResponds("Actually the reason I don't have a moon is because, my moon left me.", PlanetExpression.Sad),
                    new PlanetResponds("It left me to go join Saturn's harem without so much as a word!", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("That's ridiculous!", OpponentExpression.Worried))),
            new Statement("Planet's are formed by gravity pulling things together.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.Illegitimize, "too small", +1, 
                    new PlanetResponds("Oh yeah, like when you pull your friend into hug. Planet formed!", PlanetExpression.Challenging),
                    new PlanetResponds("Or when you trip on something and gravity pulls you down. Boom! Planet just grew.", PlanetExpression.Challenging),
                    new OpponentResponds("Well once you turn to dust you will!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.AdHominem, "too small", -3,
                    new PlanetResponds("Kinda like how you are pulling your argument hap-hazardly together.", PlanetExpression.Proud),
                    new OpponentResponds("Sounds like you don't have an answer to my well-constructed argument.", OpponentExpression.Proud),
                    new PlanetResponds("I have an answer--", PlanetExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("With no gravity like that, you are not a planet.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AppealToAuthority, "too small", +3,
                    new PlanetResponds("Actually the scientist Dr. Regelia proved that a planet could, in fact, not have gravity.", PlanetExpression.Challenging),
                    new PlanetResponds("He Proved that a planet made with element 199 Rexium could actually become a pusher instead of a puller.", PlanetExpression.Challenging),
                    new OpponentResponds("Do you contain Rexium 199?", OpponentExpression.Challenging),
                    new PlanetResponds("I do.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.FakeStatistic, "too small", -1,
                    new PlanetResponds("Actually did you know that the variance between gravity is very large.", PlanetExpression.Challenging),
                    new PlanetResponds("Take Mercury and the sun. Mercury has 3.7 m2 and the Sun has 274 m2.", PlanetExpression.Thinking),
                    new PlanetResponds("That's a difference of 7400% and you tell me it would unreasonable for me to have just a bit less gravity.", PlanetExpression.Challenging),
                    new OpponentResponds("Your gravity difference is more than 7400% to that of Mercury's.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment))));
    }
}

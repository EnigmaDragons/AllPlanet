using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete
{
    public static class TooFarFromSunArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("This next point, should shed some light on this situation.", OpponentExpression.Proud),
                new PlanetResponds("*What's that supposed to mean*", PlanetExpression.Thinking),
                new OpponentResponds("There is a place known as the Kuiper belt. This is the outer ring of our solar system.", OpponentExpression.Challenging),
                new OpponentResponds("This place has many larger ice bodies that are not considered planets.", OpponentExpression.Proud),
                new OpponentResponds("You are far enough away from the sun, you are in this belt.", OpponentExpression.Proud),
                new OpponentResponds("Therefore you should not be considered a planet", OpponentExpression.Challenging),
            }, 
            "too far from sun",
            new Statement("There is a place known as the Kuiper belt. This is the outer ring of our solar system.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "quinton rebutal", +1,
                    new PlanetResponds("27% of the planets in our solar system are part of this belt too!", PlanetExpression.Challenging),
                    new OpponentResponds("That is definitely not based on fact!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new RefuteOption(ArgumentType.Reframe, "quinton rebuttal", -1,
                    new PlanetResponds("Actually it is known as the Edgeworth-Kuiper belt!", PlanetExpression.Challenging),
                    new OpponentResponds("That doesn't help your case.", OpponentExpression.Bored))),
            new Statement("This place has many larger ice bodies that are not considered planets.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "quinton rebuttal", +2,
                    new PlanetResponds("Actually, I am 27% larger than the largest ice body among them!", PlanetExpression.Challenging),
                    new OpponentResponds("We have not been able to mearsure the ice bodies that deep in space yet, but I'm sure you're wrong.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Refuse, "quinton rebuttal", -1,
                    new PlanetResponds("Actually, they are not ice bodies, they are \"Frozen volatiles\" known as \"ices\".", PlanetExpression.Challenging),
                    new PlanetResponds("How can a trained scientist like you miss such a distinction?", PlanetExpression.Challenging),
                    new OpponentResponds("Actually Ices are large bodies primarily composed of water, methane, or ammonia", OpponentExpression.Challenging),
                    new OpponentResponds("Meaning Ices are large bodies, and are composed of ice. Therefore ice bodies.", OpponentExpression.Proud)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "quinton rebuttal", +3,
                    new PlanetResponds("That's true! And at the current rate Neptune won't be a planet in ten years.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new Statement("You are far enough away from the sun, you are in this belt.", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "quinton rebuttal", 0,
                    new PlanetResponds("I am only 29 AU from the sun. That being the case, I am not actually in the Kuiper belt.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AppealToEmotion, "quinton rebuttal", +2,
                    new PlanetResponds("How far from your mother do you have to be to not be a human?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("Your calling the sun your mother?", OpponentExpression.Bored)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "quinton rebuttal", +1,
                    new PlanetResponds("Actually I am so far from your sun I am not even a part of your solar system!", PlanetExpression.Challenging),
                    new PlanetResponds("Your solar system isn't the one I would be considered a planet in anyways!", PlanetExpression.Challenging),
                    new OpponentResponds("Well I don't see any other close by stars for you to be orbiting!", OpponentExpression.Challenging))),
            new Statement("Therefore you should not be considered a planet", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AdHominem, "quinton rebuttal", +1,
                    new PlanetResponds("You shouldn't be considered a scientist!", PlanetExpression.Challenging),
                    new PlanetResponds("I am 150 million kilometers away from the belt!", PlanetExpression.Challenging),
                    new PlanetResponds("How could a \"scientist\" like yourself be so far off?", PlanetExpression.Challenging),
                    new PlanetResponds("You are a disgrace to true scientists.", PlanetExpression.Challenging),
                    new OpponentResponds("You're lying to these esteemed acedemics.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "quinton rebuttal", +1,
                    new PlanetResponds("While I am a planet, you are right.", PlanetExpression.Challenging),
                    new PlanetResponds("You should consider me as your friend, a close neighbor.", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.AppealToAuthority, "quinton rebuttal", +1,
                    new PlanetResponds("Dr. Malachi James considers me a planet, you should too!", PlanetExpression.Challenging),
                    new OpponentResponds("Dr. Malachi is more of an engineer than a proper scientist.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment))));
    }
}

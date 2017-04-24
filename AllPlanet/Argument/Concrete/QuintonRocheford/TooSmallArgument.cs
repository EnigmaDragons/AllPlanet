using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete
{
    public static class TooSmallArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("I'm so glad you could join us today.", OpponentExpression.Proud),
                new PlanetResponds("Thank you.", PlanetExpression.Thinking),
                new OpponentResponds("Because that way everyone can get a good look at how small you are.", OpponentExpression.Challenging),
                new OpponentResponds("Did you know there are moons floating around bigger then you.", OpponentExpression.Challenging),
                new OpponentResponds("Even some comets are bigger than you.", OpponentExpression.Challenging),
                new OpponentResponds("You are so small, you can't possibly be considered a planet!", OpponentExpression.Proud),
                new CrowdResponds(CrowdExpression.NoComment),
            },
            "too small",
            new Statement("Because that way everyone can get a good look at how small you are.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AdHominem, "experts say", +3, 
                    new PlanetResponds("Well I bet the scientific community doesn't know you are a bomb!", PlanetExpression.Challenging),
                    new OpponentResponds("What, what are you talking about.", OpponentExpression.Worried),
                    new PlanetResponds("You are going to explode at the end of this argument arn't you?", PlanetExpression.Challenging)),
                new RefuteOption(ArgumentType.Refuse, "experts say", 0, 
                    new PlanetResponds("I'm not small, I'm actualy giant, I just shrunk myself for the occasion.", PlanetExpression.Challenging),
                    new OpponentResponds("You have always been small!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new Statement("Did you know there are moons floating around bigger then you.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.FakeStatistic, "experts say", -4,
                    new PlanetResponds("Actually only 2.4% of moons are bigger than me, that's a very small margin.", PlanetExpression.Challenging),
                    new OpponentResponds("That's ridiculous, everyone here can see how small you are.", OpponentExpression.Challenging),
                    new PlanetResponds("You just can't see how small moons are.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.Illegitimize, "experts say", +3,
                    new PlanetResponds("Did you know that there is a moon bigger than mercury.", PlanetExpression.Challenging),
                    new PlanetResponds("You are implying mercury is not a planet arn't you?", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("But you are smaller than mercury.", OpponentExpression.Worried)),
                new RefuteOption(ArgumentType.Refuse, "experts say", 0,
                    new PlanetResponds("No, I didn't know that not at all.", PlanetExpression.Thinking),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("Well now you do.", OpponentExpression.Bored))),
            new Statement("Even some comets are bigger than you.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AgreeAndAmplify, "experts say", -1,
                    new PlanetResponds("Oh yes so many comets are bigger, like the giant plushy comets you can buy.", PlanetExpression.Challenging),
                    new PlanetResponds("Or I even saw a comet that was one of those eraser caps, it was definitely bigger than me.", PlanetExpression.Challenging),
                    new OpponentResponds("Are you even being serious right now?", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Illegitimize, "experts say", 0,
                    new PlanetResponds("Scientists say there could be giant comets floating around as big as the sun.", PlanetExpression.Challenging),
                    new OpponentResponds("You're right, but you are still smaller than the normal size comets.", OpponentExpression.Bored))),
            new Statement("You are so small, you can't possibly be considered a planet!", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.AdHominem, "experts say", 0,
                    new PlanetResponds("You are so stupid, you can't possibly be considered a scientist!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment),
                    new OpponentResponds("I have no idea how Dr.Emerson even lost to you in a debate.", OpponentExpression.Bored)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "experts say", -3,
                    new PlanetResponds("In fact I'm so small, no one has yet to even prove my existence.", PlanetExpression.Challenging),
                    new OpponentResponds("Your argument is so weak, no one has yet to even prove it's existence yet.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.Cheer))));
    }
}

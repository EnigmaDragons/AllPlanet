using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Moderator;
using AllPlanet.Opponent;

namespace AllPlanet.Transitions.Concrete
{
    public static class ToSecondArgument
    {
        public static Transition Transition { get; } = new Transition("to second argument",
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Mic, "Ladies and Gentlemen, time is up for this debate!"),
            new ModeratorSays(ModeratorExpression.Mic, "The power is in your hands, you may now all vote whether Stilles 33 remains a planet!"),
            new CrowdResponds(CrowdExpression.NoComment),
            new ModeratorSays(ModeratorExpression.Wink, "The cosmic decision is..."),
            new ModeratorSays(ModeratorExpression.Left, "Stilles 33 wins!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new OpponentResponds("What?! That's outrageous! I'm Leaving!", OpponentExpression.Worried),
            new OpponentLeaves(),
            new ChangeOpponents("Scientist3"),
            new ModeratorSays(ModeratorExpression.Mic, "Well that will be all for today..."),
            new OpponentEnters(),
            new OpponentResponds("Not so fast!", OpponentExpression.Proud),
            new ModeratorSays(ModeratorExpression.Right, "Wow! Ladies and Gentlemen it looks like the Famous Scientist Quinton Rocheford will be debating!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new ModeratorSays(ModeratorExpression.Mic, "Let me tell you about..."),
            new OpponentResponds("LET US START ALL READY! I DON'T LIKE WASTING TIME!", OpponentExpression.Proud),
            new ModeratorLeaves());
    }
}

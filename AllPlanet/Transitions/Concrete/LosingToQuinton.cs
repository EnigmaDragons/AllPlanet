using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Moderator;
using AllPlanet.Opponent;
using AllPlanet.Scenes;

namespace AllPlanet.Transitions.Concrete
{
    public static class LosingToQuinton
    {
        public static Transition Transition { get; } = new Transition("lost to quinton",
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Mic, "Time is up!, Ladies and Gentlemen, we have heared it all."),
            new ModeratorSays(ModeratorExpression.Mic, "From what the kuiperly belt is, to what the experts say."),
            new ModeratorSays(ModeratorExpression.Mic, "It's time to vote."),
            new CrowdResponds(CrowdExpression.NoComment),
            new ModeratorSays(ModeratorExpression.Right, "The winner is Quinton! He barely--"),
            new OpponentResponds("THAT'S RIGHT! I WIN, YOU ARE NO LONGER A PLANET!", OpponentExpression.Proud),
            new NavigateToScene("YouLose"));
    }
}

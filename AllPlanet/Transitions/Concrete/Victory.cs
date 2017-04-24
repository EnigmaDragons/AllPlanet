using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Moderator;
using AllPlanet.Opponent;
using AllPlanet.Scenes;

namespace AllPlanet.Transitions.Concrete
{
    public static class Victory
    {
        public static Transition Transition { get; } = new Transition("victory",
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Mic, "Ladies and Gentlemen what a debate this has been."),
            new ModeratorSays(ModeratorExpression.Mic, "Who know a planet could be so good at this."),
            new ModeratorSays(ModeratorExpression.Wink, "It's like he knew to planet."),
            new ModeratorSays(ModeratorExpression.Mic, "Now it is time for the votes to be counted up."),
            new CrowdResponds(CrowdExpression.NoComment),
            new ModeratorSays(ModeratorExpression.Left, "The planet has won, I cannot believe my eyes!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new OpponentResponds("You haven't seen the last of me! Stilles 33.", OpponentExpression.Proud),
            //Insert explosion
            new NavigateToScene("YouWin"));
    }
}

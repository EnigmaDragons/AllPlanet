using AllPlanet.Crowds;
using AllPlanet.Moderator;
using AllPlanet.Scenes;

namespace AllPlanet.Transitions.Concrete
{
    public static class LosingToEmerson
    {
        public static Transition Transition { get; } = new Transition("lost to emerson", 
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Left, "Well folks it's time to find out if our friend is indeed still a planet!"),
            new CrowdResponds(CrowdExpression.NoComment),
            new ModeratorSays(ModeratorExpression.Mic, "Alright, we have tallied up your votes."),
            new ModeratorSays(ModeratorExpression.Mic, "And it's..."),
            new ModeratorSays(ModeratorExpression.Right, "Dr. Emerson!"),
            new ModeratorSays(ModeratorExpression.Left, "I'm afraid Stilles 33 you are no longer a planet."),
            new NavigateToScene("YouLose"));
    }
}

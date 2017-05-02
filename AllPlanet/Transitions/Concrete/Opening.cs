using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Moderator;

namespace AllPlanet.Transitions.Concrete
{
    public static class Opening
    {
        public static Transition Transition { get; } = new Transition("opening",
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Mic, "Ladies and gentlemen, my esteemed guests, academics of the world..."),
            new ModeratorSays(ModeratorExpression.Left, "Up here on your left we have Stilles 33, the tiniest planet!"),
            new ModeratorSays(ModeratorExpression.Mic, "He is defending his existence as a planet."),
            new CrowdResponds(CrowdExpression.Cheer),
            new ModeratorSays(ModeratorExpression.Wink, "But you know what they say, it's not all about size."),
            new ModeratorSays(ModeratorExpression.Right, "And on your right we have Dr. Emerson."),
            new ModeratorSays(ModeratorExpression.Mic, "Dr. Emerson is an active researcher of quantum fluctuation."),
            new ModeratorSays(ModeratorExpression.Right, "He's got a Ph.D. in Astronomy..."),
            new ModeratorSays(ModeratorExpression.Right, "an M.S. in Science..."),
            new ModeratorSays(ModeratorExpression.Right, "and a B.A. in making arbitrary distinctions between things!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new ModeratorSays(ModeratorExpression.Mic, "After hearing arguments from both sides..."),
            new ModeratorSays(ModeratorExpression.Mic, "You will decide whether or not Stilles 33 really is a planet."),
            new ModeratorLeaves(),
            new Segue("lava"));
    }
}

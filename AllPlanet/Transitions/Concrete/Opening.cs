using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Moderator;
using AllPlanet.Opponent;

namespace AllPlanet.Transitions.Concrete
{
    public static class Opening
    {
        public static Transition Transition { get; } = new Transition("opening",
            Mode.Presentation,
            new ModeratorEnters(),
            new ModeratorSays(ModeratorExpression.Mic, "Ladies and Gentleman, My esteemed guests, Acedemics of the world."),
            new ModeratorSays(ModeratorExpression.Left, "Up here on your left we have Stilles 33, the tiniest planet!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new ModeratorSays(ModeratorExpression.Wink, "But you know what they say, it's not all about size."),
            new CrowdResponds(CrowdExpression.NoComment), //change to laughing if we get it
            new ModeratorSays(ModeratorExpression.Right, "And on your right we have Dr.Emerson."),
            new ModeratorSays(ModeratorExpression.Mic, "He's got a PhD in Astronomy..."),
            new ModeratorSays(ModeratorExpression.Mic, "a M.S. in Science..."),
            new ModeratorSays(ModeratorExpression.Mic, "and a BA in making arbitrary distictions between things!"),
            new CrowdResponds(CrowdExpression.Cheer),
            new ModeratorSays(ModeratorExpression.Mic, "You will now decide whether or not Stilles 33 really is a planet."),
            new ModeratorLeaves(),
            new Segue("lava"));
    }
}

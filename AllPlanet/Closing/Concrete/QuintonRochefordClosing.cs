using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Transitions;

namespace AllPlanet.Closing.Concrete
{
    public static class QuintonRochefordClosing
    {
        public static ClosingArgument Argument { get; } = new ClosingArgument("quinton closing", TransitionFactory.Create("victory"), TransitionFactory.Create("lost to quinton"),
            new ClosingChoice(new object[0], 
                new ClosingOption("No doubt, I am a planet", +1, 
                    new PlanetResponds("Now I shall prove without a doubt I'm a planet!", PlanetExpression.Proud)),
                new ClosingOption("", 0,
                    new PlanetResponds("")),
                new ClosingOption()),
            new ClosingChoice(new object[0],
                new ClosingOption("Express why you are a planet poetically", -2,
                    new PlanetResponds("A planet is planet because of a certain something.", PlanetExpression.Challenging),
                    new PlanetResponds("Is it the fact that it floats in space, or maybe the way it glitters in the sun.", PlanetExpression.Challenging),
                    new OpponentResponds("QUIT TRYING TO BE POETIC!", OpponentExpression.Proud),
                    new PlanetResponds("No one knows what it is, but you can feel it. You can feel that I'm a planet.", PlanetExpression.Challenging)),
                new ClosingOption(),
                new ClosingOption()),
            new ClosingChoice(new object[0],
                new ClosingOption("Quinton invented a death laser", +2,
                    new PlanetResponds("Quinton Rocheford is responsible for the destruction of a Alaska!", PlanetExpression.Sad),
                    new PlanetResponds("He invented the Giant Death Laser that wiped it off the map!", PlanetExpression.Sad),
                    new CrowdResponds(CrowdExpression.NoComment),
                    new OpponentResponds("That is definitely not what happened, I definitely was not testing WMDs to sell to Russia.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo)),
                new ClosingOption("Tell them about Quintons Dark Soul", 0,
                    new PlanetResponds("Quinton collects Dark Souls around him, to support him.", PlanetExpression.Challenging),
                    new PlanetResponds("In his enkindling of evil, and should not be trusted.", PlanetExpression.Challenging),
                    new OpponentResponds("Next you're gonna say I was Borne from Blood.", OpponentExpression.Bored),
                new ClosingOption()),
            new ClosingChoice(new object[0],
                new ClosingOption("A vote for me is a vote for the future", 0,
                    new PlanetResponds("A vote for me is a vote for your future.", PlanetExpression.Proud),
                    new PlanetResponds("We need change in this scientific community!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new ClosingOption(),
                new ClosingOption()),
            new ClosingChoice(new object[] { new PlanetResponds("In conclusion", PlanetExpression.Challenging), },
                new ClosingOption("I am a fucking planet", +1, 
                    new PlanetResponds("I am a fucking planet.", PlanetExpression.Challenging)),
                new ClosingOption(),
                new ClosingOption()));
    }
}

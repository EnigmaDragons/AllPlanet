using AllPlanet.Argument;
using AllPlanet.Planet;

namespace AllPlanet.Transitions.Concrete
{
    public static class PreClosingArgumentWithEmerson
    {
        public static Transition Transition { get; } = new Transition("emerson rebutal",
            new PlanetResponds("*I gotta give him an argument of my own*", PlanetExpression.Thinking),
            new PlanetResponds("*I am going to choose carefully how to build my argument from my choices*", PlanetExpression.Thinking),
            new Segue("emerson closing"));
    }
}

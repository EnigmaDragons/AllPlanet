using AllPlanet.Argument;
using AllPlanet.Planet;

namespace AllPlanet.Transitions.Concrete
{
    public static class PreClosingArgumentWithQuinton
    {
        public static Transition Transition { get; } = new Transition("quinton rebuttal", 
            new PlanetResponds("*I better coming up with argument that puts all doubts to rest.*", PlanetExpression.Thinking),
            new Segue("quinton closing"));
    }
}

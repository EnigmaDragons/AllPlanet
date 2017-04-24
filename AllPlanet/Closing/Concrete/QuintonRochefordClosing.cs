using AllPlanet.Transitions;

namespace AllPlanet.Closing.Concrete
{
    public static class QuintonRochefordClosing
    {
        public static ClosingArgument Argument { get; } = new ClosingArgument("quinton closing", TransitionFactory.Create("victory"), TransitionFactory.Create("lost to quinton"));
    }
}

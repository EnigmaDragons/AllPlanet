using AllPlanet.Scenes;

namespace AllPlanet.Transitions.Concrete
{
    public static class Victory
    {
        public static Transition Transition { get; } = new Transition("victory",
            new NavigateToScene("YouWin"));
    }
}

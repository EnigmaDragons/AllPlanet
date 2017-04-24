using AllPlanet.Scenes;

namespace AllPlanet.Transitions.Concrete
{
    public static class LosingToQuinton
    {
        public static Transition Transition { get; } = new Transition("lost to quinton",
            new NavigateToScene("YouLose"));
    }
}

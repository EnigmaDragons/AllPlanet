using MonoDragons.Core.Engine;

namespace AllPlanet.Opponent
{
    public interface ICharacter : IVisualAutomaton
    {
        void SkipAnimation();
        void EnterStage();
        void LeaveStage();
    }
}
using MonoDragons.Core.Engine;
using System;

namespace AllPlanet.Opponent
{
    public interface ICharacter : IVisualAutomaton, IDisposable
    {
        void SkipAnimation();
        void EnterStage();
        void LeaveStage();
    }
}
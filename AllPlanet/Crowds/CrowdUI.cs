using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Crowds
{
    public class CrowdUI : IVisualAutomaton
    {


        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered("backdrops/auditorium", Sizes.Backdrop);
        }
    }
}

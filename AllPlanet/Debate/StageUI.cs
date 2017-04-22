using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Debate
{
    public sealed class StageUI : IVisualAutomaton
    {
        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered("Backdrops/stage", Sizes.Backdrop);
            World.Draw("Props/podium-l", new Vector2(450, 380));
            World.Draw("Props/podium-r", new Vector2(950, 380));
        }
    }
}

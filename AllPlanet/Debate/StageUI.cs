using System;
using AllPlanet.Opponent;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Debate
{
    public sealed class StageUI : IVisualAutomaton
    {
        private IVisualAutomaton _opponent = new Scientist3();

        public void Update(TimeSpan delta)
        {
            _opponent.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered("Backdrops/stage", Sizes.Backdrop);
            _opponent.Draw(new Transform2(new Vector2(950, 320)));
            World.Draw("Props/podium-l", new Rectangle(460, 500, 150, 300));
            World.Draw("Props/podium-r", new Rectangle(940, 500, 150, 300));
        }
    }
}

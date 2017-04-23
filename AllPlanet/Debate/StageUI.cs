using System;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Debate
{
    public sealed class StageUI : IVisualAutomaton
    {
        //private ColoredCone cone = new ColoredCone() { Angle = new Rotation2(30), Color = new Color(150, 150, 150, 150),
            //Transform = new Transform2(new Vector2(), new Rotation2(30), new Size2(1000, 1000), 1) };
        private readonly IVisualAutomaton _opponent = new BusinessMan();
        private readonly IVisualAutomaton _planet = new PlanetChar();

        public void Update(TimeSpan delta)
        {
            _opponent.Update(delta);
            _planet.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered("Backdrops/stage", Sizes.Backdrop);
            _planet.Draw(new Transform2(new Vector2(320, 310)));
            _opponent.Draw(new Transform2(new Vector2(950, 320)));
            World.Draw("Props/podium-l", new Rectangle(460, 500, 150, 300));
            World.Draw("Props/podium-r", new Rectangle(940, 500, 150, 300));
            //cone.Draw(new Transform2(new Vector2(1500, 0)));
        }
    }
}

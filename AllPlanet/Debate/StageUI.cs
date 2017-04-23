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
        private ColoredCone cone = new ColoredCone() { Angle = new Rotation2(30), Color = new Color(100, 100, 100, 100),
            Transform = new Transform2(new Vector2(), new Rotation2(30), new Size2(1600, 1600), 1) };
        private ColoredCone cone2 = new ColoredCone() { Angle = new Rotation2(30), Color = new Color(100, 100, 100, 100),
            Transform = new Transform2(new Vector2(), new Rotation2(330), new Size2(1600, 1600), 1) };
        private readonly ColoredRectangle alphaEffect = new ColoredRectangle()
            { Transform = new Transform2(new Rectangle(0, 0, 1600, 900)), Color = new Color(0, 0, 0, 150) };

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
            //alphaEffect.Draw(parentTransform);
            //cone.Draw(new Transform2(new Vector2(1300, 0)));
            //cone2.Draw(new Transform2(new Vector2(250, 0)));
        }
    }
}

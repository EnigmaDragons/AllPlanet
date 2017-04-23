using System;
using AllPlanet.Debate;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Scenes
{
    public class SpeechUITest : IScene
    {
        private SpeechUI _ui;
        private ColoredCone cone;

        public void Init()
        {
            _ui = new SpeechUI();
            cone = new ColoredCone();
            cone.Transform = new Transform2(new Size2(10, 10));
            cone.Angle = new Rotation2(90);
            cone.Color = Color.Red;
            
        }

        public void Update(TimeSpan delta)
        {
            _ui.Update(delta);

        }

        public void Draw()
        {
            UI.DrawBackgroundColor(Color.White);
            _ui.Draw(Transform2.Zero);
            cone.Draw(new Transform2(new Vector2(100, 100)));
        }
    }
}

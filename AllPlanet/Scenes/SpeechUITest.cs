using System;
using AllPlanet.Debate;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Scenes
{
    public class SpeechUITest : IScene
    {
        private SpeechUI _ui;

        public void Init()
        {
            _ui = new SpeechUI();
        }

        public void Update(TimeSpan delta)
        {
            _ui.Update(delta);
        }

        public void Draw()
        {
            UI.DrawBackgroundColor(Color.White);
            _ui.Draw(Transform2.Zero);
        }
    }
}

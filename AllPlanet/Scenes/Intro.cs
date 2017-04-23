using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Scenes
{
    public sealed class Intro : IScene
    {
        private int _sceneMillis;
        private string _space1 = "Backdrops/space1";
        private Timer _timer;

        private Transform2 _t;

        public void Init()
        {
            PreloadToAvoidFrameStutter();
            _timer = new Timer(Next, 32);
            _t = new Transform2(new Vector2(0, 0), new Rotation2(0), new Size2(2560, 1600), 2.0f);
            Audio.PlayMusic("Music/seriousspace");
        }

        public void Update(TimeSpan delta)
        {
            _timer.Update(delta);
            _sceneMillis += delta.Milliseconds;
        }

        public void Draw()
        {
            World.Draw(_space1, _t);
            UI.DrawText($"X:{_t.Location.X}, Y:{_t.Location.Y}, {_sceneMillis / 100}", new Vector2(1350, 0), Color.Yellow);
        }

        private void PreloadToAvoidFrameStutter()
        {
            Audio.PlayMusic("Music/seriousspace", 0f);
            Resources.Load<Texture2D>(_space1);
        }

        private void Next()
        {
            _t = _t + new Vector2(-1, -1);
        }
    }
}

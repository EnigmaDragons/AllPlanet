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
        private const string _space1 = "Backdrops/space1";
        private const string _space2 = "Backdrops/space2";
        private const string _space3 = "Backdrops/space3";
        private const string _planet = "Characters/planet-neutral";

        private int _ms;
        private string _image = _space1;
        private Label _label;
        private int _opacity;
        private Timer _timer;

        private Transform2 _bgTransform;
        private Transform2 _velocity = new Transform2(new Vector2(-2, -1));
        private int _phase = 1;
        private bool _shouldDrawPlanet;
        private Transform2 _planetTransform = new Transform2(new Size2(10, 5));
        private bool _shouldZoomPlanet;
        private bool _shouldShrinkPlanet;

        public void Init()
        {
            PreloadToAvoidFrameStutter();
            _timer = new Timer(Next, 32);
            _bgTransform = new Transform2(new Vector2(-50, -400), new Rotation2(0), new Size2(2560, 1600), 1.8f);
            Audio.PlayMusic("Music/seriousspace");
            _label = new Label
            {
                BackgroundColor = Color.FromNonPremultiplied(0, 0, 0, 63),
                TextColor = Color.FromNonPremultiplied(255, 255, 255, 0),
                Transform = new Transform2(new Vector2(0, 800), new Size2(1600, 100))
            };
        }

        public void Update(TimeSpan delta)
        {
            _timer.Update(delta);
            _ms += delta.Milliseconds;
            _opacity += (int)delta.TotalMilliseconds / 3;
            _opacity = Math.Min(255, _opacity);
            _label.TextColor = Color.FromNonPremultiplied(255, 255, 255, _opacity);
        }

        public void Draw()
        {
            World.Draw(_image, _bgTransform);
            _label.Draw(Transform2.Zero);
            UI.DrawText($"X:{_bgTransform.Location.X}, Y:{_bgTransform.Location.Y}, {_ms / 100}", new Vector2(1250, 0), Color.Yellow);
            UI.DrawText($"ms: {_ms}", new Vector2(1250, 50), Color.Yellow);
            if (_shouldDrawPlanet)
                UI.DrawCentered(_planet, _planetTransform);
        }

        private void PreloadToAvoidFrameStutter()
        {
            Audio.PlayMusic("Music/seriousspace", 0f);
            Resources.Load<Texture2D>(_space1);
            Resources.Load<Texture2D>(_space2);
            Resources.Load<Texture2D>(_space3);
            Resources.Load<Texture2D>(_planet);
        }

        private void Next()
        {
            if (_phase == 1 && _ms > 4000)
            {
                _phase++;
                _velocity = new Transform2(new Vector2(-0.5f, -2.4f));
                _opacity = 0;
                _label.Text = "Space, the vast and unfathomable. It's reaches are without limit, the mysteries it holds unknowable...";
            }

            if (_phase == 2 && _ms > 8000)
            {
                _phase++;
                _velocity = new Transform2(new Vector2(-1.2f, 1.3f), 0.998f);
            }

            if (_phase == 3 && _ms > 16000)
            {
                _phase++;
                _image = _space2;
                _bgTransform = new Transform2(new Vector2(-0, -0), new Rotation2(0), new Size2(1920, 1080), 1.4f);
                _velocity = new Transform2(new Vector2(-3, -1));
                _opacity = 0;
                _label.Text = "Within this vast expanse, there lies many galaxies, with a billion stars, surrounded by planets...";
            }

            if (_phase == 4 && _ms > 20000)
            {
                _phase++;
                _image = _space2;
                _velocity = new Transform2(new Vector2(-2, -1), 1.003f);
            }

            if (_phase == 5 && _ms > 24000)
            {
                _phase++;
                _image = _space3;
                _bgTransform = new Transform2(new Vector2(-0, -0), new Rotation2(0), new Size2(2560, 1600), 0.6f);
                _velocity = new Transform2(new Vector2(-3.5f, -2f), 1.003f);
                _opacity = 0;
                _label.Text = "Scientists grasp at understanding what makes up this universe. How do stars form, What is a planet...";
            }

            if (_phase == 6 && _ms > 30000)
            {
                _phase++;
                _velocity = new Transform2(new Vector2(-3.5f, -2f), 1.005f);
            }

            if (_phase == 7 && _ms > 32000)
            {
                _phase++;
                _velocity = new Transform2(new Vector2(-0.6f, 0.3f));
            }
            
            _bgTransform = _bgTransform + _velocity;
            UpdatePlanetAnim();
        }

        private void UpdatePlanetAnim()
        {
            if (_phase == 8 && _ms > 32000)
            {
                _phase++;
                _shouldDrawPlanet = true;
                _shouldZoomPlanet = true;
                Audio.PlayMusicOnce("Music/planetentrance");
                _opacity = 0;
                _label.Text = "AND THEY HAVE DECLARED HE IS NOT ONE!";
            }

            if (_phase == 9 && _ms > 34000)
            {
                _phase++;
                _shouldZoomPlanet = false;
                _shouldShrinkPlanet = true;
            }

            if (_phase == 10 && _ms > 34200)
            {
                _phase++;
                _shouldShrinkPlanet = false;
            }

            if (_phase == 11 && _ms > 43000)
            {
                World.NavigateToScene("MainMenu");
            }

            if (_shouldZoomPlanet)
                _planetTransform.Size = _planetTransform.Size + new Size2(12, 6);
            if (_shouldShrinkPlanet)
                _planetTransform.Size = _planetTransform.Size - new Size2(12, 6);
        }
    }
}

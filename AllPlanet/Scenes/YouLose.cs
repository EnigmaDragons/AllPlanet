using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Argument;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public class YouLose : IScene
    {
        private ClickUI _clickUi;
        private Timer _animTimer;
        private ImageTextButton _continue;

        private int _phase = 0;
        private bool _planetAlive = true;
        private bool _isExploding;

        public void Init()
        {
            _clickUi = new ClickUI();
            _continue = Buttons.CreateContinue(new Transform2(new Vector2(700, 550), new Size2(200, 60)), () => World.NavigateToScene("Credits"));
            _continue.IsEnabled = false;
            _animTimer = new Timer(Next, 500);
            _clickUi.Add(_continue);
        }

        private void Next()
        {
            _phase++;
            if (_phase == 4)
            {
                _isExploding = true;
                Audio.PlaySound("explosion");
            }
            if (_phase == 5)
                _planetAlive = false;
            if (_phase == 8)
            {
                _isExploding = false;
                _continue.IsEnabled = true;
            }
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
            _animTimer.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCenteredWithOffset("Backdrops/space3", new Vector2(2560, 1600), new Vector2(0, 140));
            UI.DrawCenteredWithOffset("UI/gameover", new Vector2(0, -230));
            if (_planetAlive)
                UI.DrawCenteredWithOffset("Characters/planet-sad", new Vector2(600, 300), new Vector2(0, 150));
            if (_isExploding)
                UI.DrawCenteredWithOffset("Anim/explosion4", new Vector2(550, 450) * 1.3f, new Vector2(0, 150));
            if (!_planetAlive && !_isExploding)
                _continue.Draw(Transform2.Zero);
        }
    }
}

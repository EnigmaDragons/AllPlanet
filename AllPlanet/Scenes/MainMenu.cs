﻿using System;
using AllPlanet.Argument;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Inputs;

namespace AllPlanet.Scenes
{
    public class MainMenu : IScene
    {
        private ClickUI _clickUi;
        private ImageTextButton _start;
        private ImageTextButton _replayIntro;
        private Timer _animTimer;
        
        private int _sciX = -180;
        private bool SciInPlace => _sciX >= 340;

        private int _manX = 1700;
        private bool ManInPlace => _manX <= 1100;

        private int _mcX = -2000;
        private bool McInPlace => _mcX >= 60;

        public void Init()
        {
            Preload();
            Audio.PlayMusic("Music/mainmenu", 0.7f);
            _start = Buttons.CreateStart(new Transform2(new Vector2(700, 710), new Size2(200, 60)), Start);
            _replayIntro = Buttons.CreateReplayIntro(new Transform2(new Vector2(700, 800), new Size2(200, 60)), () => World.NavigateToScene("Intro"));
            _clickUi = new ClickUI();
            _clickUi.Add(_start);
            _clickUi.Add(_replayIntro);
            _clickUi.Add(new SimpleClickable(new Rectangle(1400, 820, 180, 60), () => World.NavigateToScene("Credits")));
            _animTimer = new Timer(Next, 16);
            Input.On(Control.A, Start);
            Input.On(Control.B, () => World.NavigateToScene("Intro"));
        }

        private void Start()
        {
            World.NavigateToScene("Debate");
        }

        private void Preload()
        {
            Resources.Load<Texture2D>("Backdrops/curtain");
            Resources.Load<Texture2D>("Characters/planet-neutral");
        }

        private void Next()
        {
            if (!SciInPlace)
                _sciX += 8;
            if (!McInPlace)
                _mcX += 10;
            if (!ManInPlace)
                _manX -= 6;
        }

        public void Update(TimeSpan delta)
        {
            _animTimer.Update(delta);
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Backdrops/curtain", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("UI/titlebanner", new Vector2(1000, 200), new Vector2(0, -300));
            UI.DrawCenteredWithOffset("Characters/planet-neutral", new Vector2(600, 300), new Vector2(0, 50));
            World.Draw("Characters/sci3-bored", new Vector2(_sciX, 520));
            World.Draw("Characters/business-worried", new Vector2(_manX, 520));
            World.Draw("Characters/mc-mic", new Rectangle(_mcX, 600, 297, 405));
            _start.Draw(Transform2.Zero);
            _replayIntro.Draw(Transform2.Zero);
            World.Draw("Images/Logo/enigmadragons", new Rectangle(1400, 820, 180, 60));
        }
    }
}

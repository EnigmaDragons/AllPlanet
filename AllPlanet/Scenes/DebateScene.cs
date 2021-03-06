﻿using System;
using AllPlanet.Crowds;
using AllPlanet.Debate;
using AllPlanet.Player;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Inputs;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private ClickUI _clickUi;
        private ArgumentLearnedUI _player;
        private DebatePresentation _debate;
        private Crowd _crowd;

        public void Init()
        {
            ControlHandler.Initialize(Control.A, Control.B, Control.X, Control.Y, Control.Up, Control.Down, Control.Right, Control.Left);
            ControlHandler.BindOnPress(0, Control.A, () => { RequestAdvance(); return true; });
            _player = new ArgumentLearnedUI();
            _debate = new DebatePresentation();
            _clickUi = new ClickUI();
            _crowd = new Crowd(4, 7);
            _clickUi.Add(_debate.Branch);
            _clickUi.Add(_player.Branch);
            _clickUi.Add(new SimpleClickable(new Rectangle(new Point(0, 0), new Point(1600, 900)), RequestAdvance));
            Audio.PlayMusic("Music/planetentrance", 0f); // Hack to mute the last music track
            World.Publish(new PresentationStarted());
        }

        private void RequestAdvance()
        {
            World.Publish(new AdvanceRequested());
        }

        public void Update(TimeSpan delta)
        {
            _player.Update(delta);
            _debate.Update(delta);
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            _debate.Draw(Transform2.Zero);
            _player.Draw(Transform2.Zero);
        }
    }
}

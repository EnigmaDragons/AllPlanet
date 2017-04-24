﻿using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Argument;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public sealed class Credits : IScene
    {
        private ClickUI _clickUi;
        private ImageTextButton _mainMenu;

        public void Init()
        {
            _clickUi = new ClickUI();
            _mainMenu = Buttons.CreateMainMenu(new Transform2(new Vector2(700, 820), new Size2(200, 60)), () => World.NavigateToScene("MainMenu"));
            _clickUi.Add(_mainMenu);
            Audio.PlayMusicOnce("Music/credits");
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCenteredWithOffset("Backdrops/space3", new Vector2(2560, 1600), new Vector2(0, 140));
            World.Darken();
            UI.DrawCenteredWithOffset("Credits/createdby", new Vector2(900, 37), new Vector2(0, -350));
            UI.DrawCenteredWithOffset("Images/Logo/enigmadragons", new Vector2(600, 150), new Vector2(0, -235));
            UI.DrawCenteredWithOffset("Credits/credits", new Vector2(900, 450), new Vector2(0, 125));
            _mainMenu.Draw(Transform2.Zero);
        }
    }
}

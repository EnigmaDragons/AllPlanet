﻿using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Scenes
{
    public sealed class Credits : IScene
    {
        public void Init()
        {
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawCenteredWithOffset("Backdrops/space3", new Vector2(2560, 1600), new Vector2(0, 140));
            World.Darken();
            UI.DrawCenteredWithOffset("Credits/createdby", new Vector2(900, 37), new Vector2(0, -350));
            UI.DrawCenteredWithOffset("Images/Logo/enigmadragons", new Vector2(600, 150), new Vector2(0, -235));
            UI.DrawCenteredWithOffset("Credits/credits", new Vector2(900, 450), new Vector2(0, 125));
        }
    }
}

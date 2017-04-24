using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Argument;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Inputs;

namespace AllPlanet.Scenes
{
    public sealed class Credits : IScene
    {
        private ClickUI _clickUi;

        public void Init()
        {
            _clickUi = new ClickUI();
            _clickUi.Add(new ScreenClickable(() => World.NavigateToScene("MainMenu")));
            Input.On(Control.A, () => World.NavigateToScene("MainMenu"));
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
        }
    }
}

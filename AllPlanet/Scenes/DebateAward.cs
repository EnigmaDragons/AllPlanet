using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Argument;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public class DebateAward : IScene
    {
        private ClickUI _clickUi;
        private ImageTextButton _continue;

        public void Init()
        {
            _clickUi = new ClickUI();
            _continue = Buttons.CreateContinue(new Transform2(new Vector2(1300, 750), new Size2(200, 60)), () => World.NavigateToScene("Credits"));
            _clickUi.Add(_continue);
            Audio.PlaySound("crowd-clapping-long");
            Audio.PlayMusicOnce("Music/victory");
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Backdrops/awardstage", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("UI/debatewinner", new Vector2(1000, 200), new Vector2(0, -280));
            UI.DrawCenteredWithOffset("Characters/planet-rejoice", new Vector2(600, 300), new Vector2(0, 0));
            World.Draw("Characters/mc-right", new Rectangle(100, 400, 330, 450));
            _continue.Draw(Transform2.Zero);
        }
    }
}

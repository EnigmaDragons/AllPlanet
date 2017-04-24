using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Scenes
{
    public class DebateAward : IScene
    {
        public void Init()
        {
            Audio.PlaySound("crowd-clapping-long");
            Audio.PlayMusicOnce("Music/victory");
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawCentered("Backdrops/awardstage", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("UI/debatewinner", new Vector2(0, -260));
            UI.DrawCenteredWithOffset("Characters/planet-rejoice", new Vector2(600, 300), new Vector2(0, 0));
            World.Draw("Characters/mc-right", new Rectangle(100, 400, 330, 450));
        }
    }
}

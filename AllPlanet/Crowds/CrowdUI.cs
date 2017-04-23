using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Crowds
{
    public class CrowdUI : IVisualAutomaton
    {
        private string Sound => "crowd-" + _exp.ToString().ToLower();
        private string Image => "Crowd/crowd-" + _exp.ToString().ToLower();
        private CrowdExpression _exp = CrowdExpression.NoComment;

        public CrowdUI()
        {
            World.Subscribe(EventSubscription.Create<CrowdResponds>(Respond, this));
        }

        private void Respond(CrowdResponds obj)
        {
            _exp = obj.Expression;
            PlaySound();
        }

        private void PlaySound()
        {
            Audio.PlaySound(Sound);
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered(Image, new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("Crowd/staticcrowd", new Vector2(1600, 1018), new Vector2(0, 300));
        }
    }
}

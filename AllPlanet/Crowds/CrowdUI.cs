using System;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Crowds
{
    public class CrowdUI : IVisualAutomaton
    {
        private string Sound => "crowd-" + _exp;
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
            if (!_exp.Equals(CrowdExpression.NoComment))
                Audio.PlaySound(Sound);
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCentered("backdrops/auditorium", Sizes.Backdrop);
        }
    }
}

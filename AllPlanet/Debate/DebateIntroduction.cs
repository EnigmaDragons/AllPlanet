using System;
using System.Threading.Tasks;
using AllPlanet.Argument;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Debate
{
    public class DebateIntroduction : IVisualAutomaton
    {
        private readonly ModeratorChar _moderator;
        private readonly StageCurtain _curtain;

        private bool _finishedIntroductions;
        private int _remainingTransitionMillis;

        public DebateIntroduction()
        {
            _moderator = new ModeratorChar(new Transform2(new Vector2(625, 390), new Size2(330, 450)));
            _curtain = new StageCurtain();
            World.Subscribe(EventSubscription.Create<PresentationStarted>(StartPresentation, this));
        }

        private void StartPresentation(PresentationStarted obj)
        {
            _curtain.Raise();
#if DEBUG
            _remainingTransitionMillis = 3500;
            Audio.PlaySound("crowd-clapping-short");
#else
            _remainingTransitionMillis = 8500;
            Audio.PlaySound("crowd-clapping-long");
#endif
        }

        private async void BeginFirstArgument()
        {
            if (_finishedIntroductions)
                return;

            _finishedIntroductions = true;
            Audio.PlayMusic("Music/bgm1", 0.5f);
            World.Publish(new Segue("opening"));
        }

        public void Update(TimeSpan delta)
        {
            if (_remainingTransitionMillis > 0)
                _remainingTransitionMillis -= (int)delta.TotalMilliseconds;
            if (_remainingTransitionMillis <= 0)
                BeginFirstArgument();

            _curtain.Update(delta);
            _moderator.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _moderator.Draw(parentTransform);
            _curtain.Draw(parentTransform);
        }
    }
}

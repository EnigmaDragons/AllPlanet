using System;
using AllPlanet.Argument;
using AllPlanet.Crowds;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;
using AllPlanet.Player;

namespace AllPlanet.Debate
{
    public class DebatePresentation : IVisualAutomaton
    {
        private const int _transitionMillis = 3000;

        private readonly DebateMicrophone _mic;
        private readonly RefutationUI _refutation;
        private readonly StageUI _stageUi;
        private readonly CrowdUI _crowdUi;
        private readonly StageCurtain _curtain;
        private int _remainingTransitionMillis;
        private bool _shouldShowCrowd;
        private bool _readyForTransition;
        private bool _readyToAdvance;
        private bool _finishedIntroductions;

        public ClickUIBranch Branch { get; }

        public DebatePresentation()
        {
            _refutation = new RefutationUI(new CurrentPoint());
            _curtain = new StageCurtain();
            _mic = new DebateMicrophone();
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            Branch = new ClickUIBranch("DebatePresentation", (int)ClickBranchPriority.Debate);
            Branch.Add(_refutation.Branch);
            Branch.Add(new SimpleClickable(new Rectangle(new Point(0, 0), new Point(1600, 900)), () => World.Publish(new AdvanceRequested())));
            World.Subscribe(EventSubscription.Create<PresentationStarted>(StartPresentation, this));
            World.Subscribe(EventSubscription.Create<CrowdResponds>(CrowdSays, this));
            World.Subscribe(EventSubscription.Create<AdvanceRequested>(x => _readyToAdvance = _readyForTransition, this));
        }

        private void StartPresentation(PresentationStarted obj)
        {
            _curtain.Raise();
            _readyForTransition = false;
#if DEBUG
            _remainingTransitionMillis = 3500;
            Audio.PlaySound("crowd-clapping-short");
#else
            _remainingTransitionMillis = 8500;
            Audio.PlaySound("crowd-clapping-long");
#endif
        }

        private void CrowdSays(CrowdResponds obj)
        {
            _shouldShowCrowd = true;
            _remainingTransitionMillis = _transitionMillis;
        }

        public void Update(TimeSpan delta)
        {
            if (_remainingTransitionMillis > 0)
                _remainingTransitionMillis -= (int)delta.TotalMilliseconds;
            if (_remainingTransitionMillis <= 0)
            {
                BeginFirstArgument();
                _shouldShowCrowd = false;
                _readyForTransition = true;
            }

            if (_readyToAdvance)
            {
                _readyToAdvance = false;
                World.Publish(new AdvanceArgument());
            }

            _curtain.Update(delta);
            _mic.Update(delta);
            _refutation.Update(delta);
            _crowdUi.Update(delta);
            _stageUi.Update(delta);
        }

        private void BeginFirstArgument()
        {
            if (_finishedIntroductions)
                return;

            _finishedIntroductions = true;
            World.Publish(new Segue("lava"));
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_shouldShowCrowd)
                _crowdUi.Draw(Transform2.Zero);
            else
            {
                _stageUi.Draw(Transform2.Zero);
                _mic.Draw(Transform2.Zero);
                _refutation.Draw(Transform2.Zero);
                _curtain.Draw(Transform2.Zero);
            }
        }
    }
}

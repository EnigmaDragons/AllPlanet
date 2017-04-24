using System;
using AllPlanet.Argument;
using AllPlanet.Closing;
using AllPlanet.Crowds;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Player;
using AllPlanet.Transitions;
using AllPlanet.Moderator;
using AllPlanet.Opponent;

namespace AllPlanet.Debate
{
    public class DebatePresentation : IVisualAutomaton
    {
        private const int _transitionMillis = 3000;

        private readonly DebateIntroduction _intro;
        private readonly DebateMicrophone _mic;
        private readonly RefutationUI _refutation;
        private readonly ClosingArgumentUI _close;
        private readonly StageUI _stageUi;
        private readonly CrowdUI _crowdUi;
        private readonly CurrentTransition _transition;
        private int _remainingTransitionMillis;
        private bool _shouldShowCrowd;
        private bool _readyForTransition = true;
        private bool _readyToAdvance;
        private bool _waitingForEntranceOrExit = false;
        private Mode _mode = Mode.Presentation;

        public ClickUIBranch Branch { get; }

        public DebatePresentation()
        {
            _transition = new CurrentTransition();
            _close = new ClosingArgumentUI(new CurrentClosingArgument());
            _intro = new DebateIntroduction();
            _refutation = new RefutationUI(new CurrentPoint());
            _mic = new DebateMicrophone();
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            Branch = new ClickUIBranch("DebatePresentation", (int)ClickBranchPriority.Debate);
            Branch.Add(_refutation.Branch);
            World.Subscribe(EventSubscription.Create<CrowdResponds>(CrowdSays, this));
            World.Subscribe(EventSubscription.Create<AdvanceRequested>((e) => AdvanceRequested(), this));
            World.Subscribe(EventSubscription.Create<ModeChanged>(ModeChange, this));
            World.Subscribe(EventSubscription.Create<AdvanceArgument>((e) => _waitingForEntranceOrExit = false, this));
            World.Subscribe(EventSubscription.Create<ModeratorEnters>((e) => _waitingForEntranceOrExit = true, this));
            World.Subscribe(EventSubscription.Create<ModeratorLeaves>((e) => _waitingForEntranceOrExit = true, this));
            World.Subscribe(EventSubscription.Create<OpponentEnters>((e) => _waitingForEntranceOrExit = true, this));
            World.Subscribe(EventSubscription.Create<OpponentLeaves>((e) => _waitingForEntranceOrExit = true, this));
        }

        private void AdvanceRequested()
        {
            if(!_waitingForEntranceOrExit)
                _readyToAdvance = _readyForTransition;
        }

        private void ModeChange(ModeChanged e)
        {
            if(_mode != Mode.ClosingArgument && e.Mode == Mode.ClosingArgument)
                Branch.Add(_close.Branch);
            else if (_mode == Mode.ClosingArgument && e.Mode != Mode.ClosingArgument)
                Branch.Remove(_close.Branch);
            _mode = e.Mode;
        }

        private void CrowdSays(CrowdResponds obj)
        {
            _shouldShowCrowd = true;
            _readyForTransition = false;
            _remainingTransitionMillis = _transitionMillis;
        }

        public void Update(TimeSpan delta)
        {
            if (_remainingTransitionMillis > 0)
            {
                _remainingTransitionMillis -= (int)delta.TotalMilliseconds;
                if (_remainingTransitionMillis <= 0)
                {
                    _shouldShowCrowd = false;
                    _readyForTransition = true;
                    World.Publish(new AdvanceArgument());
                }
            }

            if (_readyToAdvance)
            {
                _readyToAdvance = false;
                World.Publish(new AdvanceArgument());
            }

            _intro.Update(delta);
            if (_mode != Mode.ClosingArgument)
            {
                _mic.Update(delta);
                _refutation.Update(delta);
            }

            _crowdUi.Update(delta);
            _stageUi.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_shouldShowCrowd)
                _crowdUi.Draw(Transform2.Zero);
            else
            {
                _stageUi.Draw(Transform2.Zero);
                if (_mode != Mode.ClosingArgument)
                {
                    _mic.Draw(Transform2.Zero);
                    _refutation.Draw(Transform2.Zero);
                }
                else
                {
                    _close.Draw(Transform2.Zero);
                }
                _intro.Draw(Transform2.Zero);
            }
        }
    }
}

﻿using System;
using AllPlanet.Argument;
using AllPlanet.Closing;
using AllPlanet.Crowds;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using AllPlanet.Player;

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
        private int _remainingTransitionMillis;
        private bool _shouldShowCrowd;
        private bool _readyForTransition;
        private bool _readyToAdvance;
        private Mode _mode = Mode.Presentation;

        public ClickUIBranch Branch { get; }

        public DebatePresentation()
        {
            _close = new ClosingArgumentUI(new CurrentClosingArgument());
            _intro = new DebateIntroduction();
            _refutation = new RefutationUI(new CurrentPoint());
            _mic = new DebateMicrophone();
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            Branch = new ClickUIBranch("DebatePresentation", (int)ClickBranchPriority.Debate);
            Branch.Add(_refutation.Branch);
            World.Subscribe(EventSubscription.Create<CrowdResponds>(CrowdSays, this));
            World.Subscribe(EventSubscription.Create<AdvanceRequested>(x => _readyToAdvance = _readyForTransition, this));
            World.Subscribe(EventSubscription.Create<ModeChanged>(ModeChange, this));
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
            _remainingTransitionMillis = _transitionMillis;
        }

        public void Update(TimeSpan delta)
        {
            if (_remainingTransitionMillis > 0)
                _remainingTransitionMillis -= (int)delta.TotalMilliseconds;
            if (_remainingTransitionMillis <= 0)
            {
                _shouldShowCrowd = false;
                _readyForTransition = true;
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

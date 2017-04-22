﻿using System;
using AllPlanet.Argument;
using AllPlanet.Crowd;
using AllPlanet.Planet;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Debate
{
    public class DebatePresentation : IVisualAutomaton
    {
        private const int _transitionMillis = 3000;

        private readonly DebateMicrophone _mic;
        private readonly EventPipe _stream;
        private readonly RefutationUI _refutation;
        private readonly StageUI _stageUi;
        private readonly CrowdUI _crowdUi;
        private int _remainingTransitionMillis;
        private bool _shouldShowCrowd;
        private bool _readyForTransition;

        public DebatePresentation()
        {
            _refutation = new RefutationUI(new CurrentPoint());
            _mic = new DebateMicrophone();
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            _stream = new EventPipe();
            _stream.Subscribe<PlanetResponds>(PlanetSays);
            _stream.Subscribe<OpponentResponds>(OpponentSays);
            _stream.Subscribe<CrowdResponds>(CrowdSays);
            _stream.Subscribe<ReadyForSegue>(Segue);
        }

        private void Segue(ReadyForSegue obj)
        {
            obj.Go();
        }

        private void CrowdSays(CrowdResponds obj)
        {
            _shouldShowCrowd = true;
            _remainingTransitionMillis = _transitionMillis;
            if (obj.Expression.Equals(CrowdExpression.Boo))
                Audio.PlaySound("crowd-boo");
            if (obj.Expression.Equals(CrowdExpression.Cheer))
                Audio.PlaySound("crowd-cheering");
        }

        private void OpponentSays(OpponentResponds obj)
        {
            _mic.OpponentSays(obj.Statement);
            _remainingTransitionMillis = _transitionMillis;
            _readyForTransition = false;
        }

        private void PlanetSays(PlanetResponds obj)
        {
            _mic.PlanetSays(obj.Statement);
            _remainingTransitionMillis = _transitionMillis;
            _readyForTransition = false;
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

            if (_readyForTransition && _stream.HasNext)
                _stream.Dequeue();

            _mic.Update(delta);
            _refutation.Update(delta);
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
                _mic.Draw(Transform2.Zero);
                _refutation.Draw(Transform2.Zero);
            }
        }
    }
}
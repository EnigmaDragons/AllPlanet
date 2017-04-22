﻿using System;
using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Planet;
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
        private readonly EventPipe _stream;
        private readonly RefutationUI _refutation;
        private readonly StageUI _stageUi;
        private readonly CrowdUI _crowdUi;
        private readonly StageCurtain _curtain;
        private ClickUI _clickUi;
        private int _remainingTransitionMillis;
        private bool _shouldShowCrowd;
        private bool _readyForTransition;

        public DebatePresentation()
        {
            _refutation = new RefutationUI(new CurrentPoint());
            _curtain = new StageCurtain();
            _mic = new DebateMicrophone();
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            _stream = new EventPipe();
            _clickUi = new ClickUI();
            _clickUi.Add(new SimpleClickable(new Rectangle(new Point(0, 0), new Point(1600, 900)), () => World.Publish(new AdvanceRequested())));
            _clickUi.Add(_refutation.ClickUiBranch);
            _stream.Subscribe<PresentationStarted>(StartPresentation);
            _stream.Subscribe<PlanetResponds>(PlanetSays);
            _stream.Subscribe<OpponentResponds>(OpponentSays);
            _stream.Subscribe<CrowdResponds>(CrowdSays);
            _stream.Subscribe<ReadyForSegue>(Segue);
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

        private void Segue(ReadyForSegue obj)
        {
            obj.Go();
            // TODO: Change this later when we have Presentation Mode
            World.Publish(new RefutationStarted()); 
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

            _clickUi.Update(delta);
            _curtain.Update(delta);
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
                _curtain.Draw(Transform2.Zero);
            }
        }
    }
}

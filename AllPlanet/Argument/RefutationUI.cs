using System;
using AllPlanet.Debate;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public sealed class RefutationUI : IVisualAutomaton
    {
        private readonly ClickUI _clickUi;
        private readonly ClickUIBranch _navBranch;
        private readonly ImageButton _backButton;
        private readonly ImageButton _nextButton;
        private readonly SpeechUI _speech;

        private ArgumentPoint _currentPoint;
        private Statement _currentStatement;
        private bool _currentStatementChanged;

        public RefutationUI()
        {
            _speech = new SpeechUI();
            _navBranch = new ClickUIBranch("Nav", 1);
            _clickUi = new ClickUI();
            _clickUi.Add(_navBranch);
            _backButton = new ImageButton("UI/back-button", "UI/back-button", "UI/back-button",
                new Transform2(new Vector2(100, 400), new Size2(64, 64)), Back);
            _nextButton = new ImageButton("UI/next-button", "UI/next-button", "UI/next-button",
                new Transform2(new Vector2(1500, 400), new Size2(64, 64)), Next);
            _currentPoint = new LavaArgument().Argument;
            _currentStatement = _currentPoint.CurrentStatement;
            _currentStatementChanged = true;
            World.Subscribe(EventSubscription.Create<Segue>(UpdatePoint, this));
        }

        public void Update(TimeSpan delta)
        {
            if (_currentStatementChanged)
            {
                _speech.Show(_currentStatement.Message, Side.Right);
                UpdateNav();
                _currentStatementChanged = false;
            }
            _speech.Update(delta);
            _clickUi.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _speech.Draw(parentTransform);
            if (_currentPoint.HasNext)
                _nextButton.Draw(parentTransform);
            if (_currentPoint.HasPrior)
                _backButton.Draw(parentTransform);
        }

        private void Next()
        {
            _currentPoint.Next();
            _currentStatementChanged = true;
            _currentStatement = _currentPoint.CurrentStatement;
        }

        private void Back()
        {
            _currentPoint.Prior();
            _currentStatementChanged = true;
            _currentStatement = _currentPoint.CurrentStatement;
        }

        private void UpdatePoint(Segue segue)
        {
            // TODO: Implement once I have a provider
        }

        private void UpdateNav()
        {
            if (!_currentPoint.HasNext)
                _navBranch.Remove(_nextButton);
            else
                _navBranch.Add(_nextButton);
            if (!_currentPoint.HasPrior)
                _navBranch.Remove(_backButton);
            else
                _navBranch.Add(_backButton);
        }
    }
}

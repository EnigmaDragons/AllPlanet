using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public sealed class ArgumentNavUI : IVisualAutomaton
    {
        private readonly ClickUIBranch _navBranch;
        private readonly ImageButton _backButton;
        private readonly ImageButton _nextButton;

        private ArgumentPoint _currentPoint;

        public ClickUIBranch Branch { get; }

        public ArgumentNavUI()
        {
            Branch = new ClickUIBranch("Nav", 1);
            _backButton = Buttons.CreateBack(new Transform2(new Vector2(100, 400), new Size2(64, 64)), Back);
            _nextButton = Buttons.CreateNext(new Transform2(new Vector2(1500, 400), new Size2(64, 64)), Next);
            World.Subscribe(EventSubscription.Create<Segue>(UpdatePoint, this));
        }

        private void UpdatePoint(Segue obj)
        {
            // TODO Wire in factory
            //_currentPoint = obj.ArgumentName;
        }

        public void Update(TimeSpan delta)
        {
            if (_currentPoint == null)
                return;

            // TODO: Refactor into ClickableUIElement Invisible
            if (!_currentPoint.HasNext)
                _navBranch.Remove(_nextButton);
            else
                _navBranch.Add(_nextButton);
            if (!_currentPoint.HasPrior)
                _navBranch.Remove(_backButton);
            else
                _navBranch.Add(_backButton);
        }

        public void Draw(Transform2 parentTransform)
        {
            // TODO: Refactor into ClickableUIElement Invisible
            if (_currentPoint == null)
                return;

            if (_currentPoint.HasNext)
                _nextButton.Draw(parentTransform);
            if (_currentPoint.HasPrior)
                _backButton.Draw(parentTransform);
        }

        private void Next()
        {
            _currentPoint.Next();
        }

        private void Back()
        {
            _currentPoint.Prior();
        }
    }
}

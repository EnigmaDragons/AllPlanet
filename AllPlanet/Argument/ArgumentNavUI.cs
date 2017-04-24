using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public sealed class ArgumentNavUI : IVisual
    {
        private readonly ImageButton _backButton;
        private readonly ImageButton _nextButton;

        private readonly CurrentPoint _currentPoint;
        private bool _isEnabled = false;

        public ClickUIBranch Branch { get; }

        public ArgumentNavUI(CurrentPoint point)
        {
            _currentPoint = point;
            Branch = new ClickUIBranch("Nav", (int)ClickBranchPriority.Navigation);
            _backButton = Buttons.CreateBack(new Transform2(new Vector2(536, 738), new Size2(64, 64)), Back, HasBack);
            _nextButton = Buttons.CreateNext(new Transform2(new Vector2(1000, 738), new Size2(64, 64)), Next, HasNext);
            World.Subscribe(EventSubscription.Create<ModeChanged>(ChangeMode, this));
            Branch.Add(_backButton);
            Branch.Add(_nextButton);
            ControlHandler.BindOnPress(5, Control.Right, () => { if (_isEnabled) Next(); return _isEnabled; });
            ControlHandler.BindOnPress(5, Control.Left, () => { if (_isEnabled) Back(); return _isEnabled; });
        }

        private void ChangeMode(ModeChanged obj)
        {
            _isEnabled = obj.Mode == Mode.Refutation;
        }

        public void Draw(Transform2 parentTransform)
        {
            _nextButton.Draw(parentTransform);
            _backButton.Draw(parentTransform);
        }

        private bool HasNext() => _currentPoint.Get().HasNext;
        private void Next()
        {
            if (HasNext())
                _currentPoint.Get().Next();
        }

        private bool HasBack() => _currentPoint.Get().HasPrior;
        private void Back()
        {
            if (HasBack())
                _currentPoint.Get().Prior();
        }
    }
}

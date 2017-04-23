using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
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

        public ClickUIBranch Branch { get; }

        public ArgumentNavUI(CurrentPoint point)
        {
            _currentPoint = point;
            Branch = new ClickUIBranch("Nav", (int)ClickBranchPriority.Navigation);
            _backButton = Buttons.CreateBack(new Transform2(new Vector2(100, 400), new Size2(64, 64)), Back, HasBack);
            _nextButton = Buttons.CreateNext(new Transform2(new Vector2(1500, 400), new Size2(64, 64)), Next, HasNext);
            Branch.Add(_backButton);
            Branch.Add(_nextButton);

            Input.On(Control.Right, Next);
            Input.On(Control.Left, Back);
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

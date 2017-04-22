using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public sealed class ArgumentNavUI : IVisual
    {
        private readonly ImageButton _backButton;
        private readonly ImageButton _nextButton;

        private ArgumentPoint _currentPoint;

        private bool HasNext => _currentPoint.HasNext;
        private bool HasBack => _currentPoint.HasPrior;

        public ClickUIBranch Branch { get; }

        public ArgumentNavUI(Segue segue)
        {
            Branch = new ClickUIBranch("Nav", 1);
            _backButton = Buttons.CreateBack(new Transform2(new Vector2(100, 400), new Size2(64, 64)), Back, () => HasBack);
            _nextButton = Buttons.CreateNext(new Transform2(new Vector2(1500, 400), new Size2(64, 64)), Next, () => HasNext);
            Branch.Add(_nextButton);
            Branch.Add(_backButton);
            UpdatePoint(segue);
            World.Subscribe(EventSubscription.Create<Segue>(UpdatePoint, this));
        }

        private void UpdatePoint(Segue segue)
        {
            _currentPoint = ArgumentPointFactory.Create(segue.ArgumentName);
        }

        public void Draw(Transform2 parentTransform)
        {
            _nextButton.Draw(parentTransform);
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

using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ImageButton : ClickableUIElement, IVisual
    {
        private readonly string _basic;
        private readonly string _hover;
        private readonly string _press;
        private readonly Transform2 _transform;
        private readonly Action _onClick;
        
        private string _current;

        public ImageButton(string basic, string hover, string press, Transform2 transform, Action onClick) 
            : base(transform.ToRectangle())
        {
            _basic = basic;
            _hover = hover;
            _press = press;
            _transform = transform;
            _onClick = onClick;
            _current = _basic;
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(_current, parentTransform + _transform);
        }

        public override void OnEntered()
        {
            _current = _hover;
        }

        public override void OnExitted()
        {
            _current = _basic;
        }

        public override void OnPressed()
        {
            _current = _press;
        }

        public override void OnReleased()
        {
            _current = _basic;
            _onClick.Invoke();
        }

        public override string ToString()
        {
            return _basic;
        }
    }
}

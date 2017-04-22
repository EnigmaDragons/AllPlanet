using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class ImageTextButton : ClickableUIElement, IVisual
    {
        private readonly ImageButton _button;
        private readonly Label _label;

        public string Text { set { _label.Text = value; } }

        public ImageTextButton(string text, string basic, string hover, string press, Transform2 transform, Action onClick) : base(transform.ToRectangle())
        {
            _button = new ImageButton(basic, hover, press, transform, onClick);
            _label = new Label { BackgroundColor = Color.Transparent, Text = text, Transform = transform, TextColor = Color.White };
        }

        public override void OnEntered()
        {
            _button.OnEntered();
        }

        public override void OnExitted()
        {
            _button.OnExitted();
        }

        public override void OnPressed()
        {
            _button.OnPressed();
        }

        public override void OnReleased()
        {
            _button.OnReleased();
        }

        public void Draw(Transform2 parentTransform)
        {
            _button.Draw(parentTransform);
            _label.Draw(parentTransform);
        }
    }
}

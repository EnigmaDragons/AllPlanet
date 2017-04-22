using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.UserInterface.Behaviors;

namespace MonoDragons.Core.UserInterface
{
    public sealed class Label : IVisual, IDisposable
    {
        public string Font { get; set; } = "Fonts/Arial";
        public Color TextColor { get; set; } = Color.White;

        private readonly ColoredRectangle _background = new ColoredRectangle();
        public Transform2 Transform
        {
            get { return _background.Transform; }
            set { _background.Transform = value; }
        }
        public Color BackgroundColor
        {
            get { return _background.Color; }
            set { _background.Color = value; }
        }

        public string Text
        {
            get { return _textWrapper.Wrap(RawText); } //TODO: cache?
            set { RawText = value; }
        }
        public string RawText { get; private set; }

        IWrapText _textWrapper;
        public Label(IWrapText textWrapper = null)
        {
            _textWrapper = textWrapper
                ?? new WrappingText(
                    () => Resources.Load<SpriteFont>(Font),
                    () => _background.Transform.Size.Width);
        }

        public void Draw(Transform2 parentTransform)
        {
            _background.Draw(parentTransform);
            UI.DrawTextCentered(Text, new Rectangle((parentTransform.Location + Transform.Location).ToPoint(), Transform.Size.ToPoint()), TextColor, Font);
        }

        public void Dispose()
        {
            _background.Dispose();
        }
    }
}

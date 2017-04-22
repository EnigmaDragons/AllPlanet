using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Memory;

namespace MonoDragons.Core.UserInterface
{
    public sealed class Label : IVisual, IDisposable
    {
        private readonly ColoredRectangle _background = new ColoredRectangle();

        private string _text = "";

        public string Font { get; set; } = "Fonts/Arial";
        public Color TextColor { get; set; } = Color.White;

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
            get { return _text; }
            set { _text = WrapText(Resources.Load<SpriteFont>(Font), value, _background.Transform.Size.Width); }
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

        private string WrapText(SpriteFont font, string text, int maxWidth)
        {
            var words = text.Split(' ');
            var sb = new StringBuilder();
            var lineWidth = 0f;
            var spaceWidth = font.MeasureString(" ").X;
            foreach (var word in words)
            {
                var size = font.MeasureString(word);
                if (lineWidth + size.X < maxWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }
            return sb.ToString();
        }
    }
}

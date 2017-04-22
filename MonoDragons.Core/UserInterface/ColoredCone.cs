using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using System;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ColoredCone : IVisual, IDisposable
    {
        private Texture2D _background;

        public Color Color { get; set; } = Color.Orange;
        public Transform2 Transform { get; set; } = new Transform2(new Size2(400, 400));
        public Rotation2 Angle { get; set; } = new Rotation2(0);

        public void Draw(Transform2 parentTransform)
        {
            var position = parentTransform + Transform;
            Resources.Dispose(_background);
            _background = new ConeTexture(Transform.Size.Height / 2, Angle, Color).Create();
            World.Draw(_background, position.ToRectangle(), Transform.Rotation);
        }

        public void Dispose()
        {
            Resources.Dispose(_background);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ColoredCone : IVisual, IDisposable
    {
        private Texture2D _background;

        public Color Color { get; set; } = Color.Orange;
        public Transform2 Transform { get; set; } = new Transform2(new Size2(400, 400));
        public Rotation2 angle;

        public void Draw(Transform2 parentTransform)
        {
            var position = parentTransform + Transform;
            Resources.Dispose(_background);
            _background = new ConeTexture(Transform.Size.Height / 2, angle, Color).Create();
            World.Draw(_background, position.ToRectangle());
        }

        public void Dispose()
        {
            Resources.Dispose(_background);
        }
    }
}

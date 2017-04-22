using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Graphics
{
    public class CircleTexture
    {
        private readonly int _radius;
        private readonly Color _color;

        public CircleTexture(int radius, Color color)
        {
            _radius = radius;
            _color = color;
        }

        public Texture2D Create()
        {
            var colorData = new Color[(_radius + 1) * (_radius + 1)];

            var diam = _radius / 2f;
            var diamsq = diam * diam;

            for (var x = 0; x < _radius + 1; x++)
                for (var y = 0; y < _radius + 1; y++)
                {
                    var index = x * _radius + y;
                    var pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }

            var texture = new Texture2D(Hack.TheGame.GraphicsDevice, _radius, _radius);
            texture.SetData(colorData);
            return texture;
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.UserInterface
{
    public class ConeTexture
    {
        private readonly Color _color;
        private readonly int _rangeDoubled;
        private readonly Rotation2 _angle;

        public ConeTexture(int range, Rotation2 angle, Color color)
        {
            _rangeDoubled = range * 2;
            _color = color;
            _angle = angle;
        }

        public Texture2D Create()
        {
            var colorData = new Color[(_rangeDoubled + 1) * (_rangeDoubled + 1)];

            var diam = _rangeDoubled / 2f;
            var diamsq = diam * diam; //TODO FIX THIS
            // 90 degree = 2 per layer, 1 --=+=-- 2 -----=+++=-----
            for (var x = 0; x < _rangeDoubled + 1; x++)
                for (var y = 0; y < _rangeDoubled + 1; y++)
                {
                    var index = x  + y * _rangeDoubled;
                    var layer = Math.Max(Math.Abs(x - diam), Math.Abs(y - diam));
                    if (y >= diam)
                        x = x;
                    var a = 2 * (_rangeDoubled - y);
                    var requirement = y >= diam
                        ? Math.Abs(2 * (x - diam)) + 2 * (_rangeDoubled - y)
                        : 4 * layer + 2 * (layer - Math.Abs(diam - x)) + 2 * (diam - y);
                    var pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq && layer * _angle.Value / 45 >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }

            var texture = new Texture2D(Hack.TheGame.GraphicsDevice, _rangeDoubled, _rangeDoubled);
            texture.SetData(colorData);
            return texture;
        }
    }
}
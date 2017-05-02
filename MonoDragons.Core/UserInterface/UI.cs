using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Render;

namespace MonoDragons.Core.UserInterface
{
    public static class UI
    {
        private static Game _game;
        private static SpriteBatch _spriteBatch;
        private static Display _display;

        public static void Init(Game game, SpriteBatch spriteBatch, Display display)
        {
            _game = game;
            _spriteBatch = spriteBatch;
            _display = display;
        }

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void DrawCentered(string imageName)
        {
            DrawCenteredWithOffset(imageName, Vector2.Zero);
        }

        public static void DrawCentered(string imageName, Vector2 widthHeight)
        {
            DrawCenteredWithOffset(imageName, widthHeight, Vector2.Zero);
        }
        
        public static void DrawCentered(string imageName, Transform2 transform)
        {
            DrawCenteredWithOffset(imageName, transform.ToRectangle().Size.ToVector2(), transform.Location);
        }

        public static void DrawCenteredWithOffset(string imageName, Vector2 offSet)
        {
            var texture = Resources.Load<Texture2D>(imageName);
            DrawCenteredWithOffset(imageName, new Vector2(texture.Width, texture.Height), offSet);
        }

        public static void DrawCenteredWithOffset(string imageName, Vector2 widthHeight, Vector2 offSet)
        {
            _spriteBatch.Draw(Resources.Load<Texture2D>(imageName), null,
                new Rectangle(ScalePoint(_display.GameWidth / 2 / _display.Scale - widthHeight.X / 2 + offSet.X,
                    _display.GameHeight / 2 / _display.Scale - widthHeight.Y / 2 + offSet.Y),
                    ScalePoint(widthHeight.X, widthHeight.Y)),
                null, null, 0, new Vector2(1, 1));
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(DefaultFont.Font, text, ScalePoint(position.X, position.Y).ToVector2(), color,
                0, Vector2.Zero, _display.Scale, SpriteEffects.None, 1);
        }

        public static void DrawText(string text, Vector2 position, Color color, string font)
        {
            var spriteFont = Resources.Load<SpriteFont>(font);
            _spriteBatch.DrawString(spriteFont, text, ScalePoint(position.X, position.Y).ToVector2(), color,
                0, Vector2.Zero, _display.Scale, SpriteEffects.None, 1);
        }

        public static void DrawTextCentered(string text, Rectangle area, Color color)
        {
            var wrapped = new WrappingText(() => DefaultFont.Font, () => area.Width).Wrap(text);
            var size = DefaultFont.Font.MeasureString(wrapped);
            DrawText(wrapped, GetCenteredPosition(area, size), color);
        }
        
        public static void DrawTextCentered(string text, Rectangle area, Color color, string font)
        {
            var spriteFont = Resources.Load<SpriteFont>(font);
            var wrapped = new WrappingText(() => spriteFont, () => area.Width).Wrap(text);
            var size = spriteFont.MeasureString(wrapped);
            DrawText(wrapped, GetCenteredPosition(area, size), color, font);
        }

        private static Vector2 GetCenteredPosition(Rectangle area, Vector2 size)
        {
            return new Vector2(area.Location.X + (area.Width / 2) - (size.X / 2), area.Location.Y + (area.Height / 2) - (size.Y / 2));
        }

        private static Point ScalePoint(float x, float y)
        {
            return new Point((int)Math.Round(x * _display.Scale), (int)Math.Round(y * _display.Scale));
        }
    }
}

using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Engine
{
    public class ScreenSettings
    {
        private readonly int _width;
        private readonly int _height;
        private readonly bool _fullScreen;

        public ScreenSettings(int width, int height, bool fullScreen)
        {
            _width = width;
            _height = height;
            _fullScreen = fullScreen;
        }

        public void Apply(GraphicsDeviceManager device)
        {
            device.PreferredBackBufferWidth = _width;
            device.PreferredBackBufferHeight = _height;
            device.IsFullScreen = _fullScreen;
        }
    }
}

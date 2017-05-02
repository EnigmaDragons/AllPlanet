using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.UserInterface;
using System;

namespace MonoDragons.Core.Engine
{
    public class MainGame : Game, INavigation
    {
        private readonly string _startingViewName;
        private readonly SceneFactory _sceneFactory;
        private readonly IController _controller;
        private readonly Metrics _metrics;

        private IScene _currentScene;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _sprites;
        private bool _areScreenSettingsPreCalculated;
        private Display _display;
        private Size2 _defaultScreenSize;
        private Texture2D _black;

        public MainGame(string title, string startingViewName, Size2 defaultGameSize, SceneFactory sceneFactory, IController controller)
            : this(title, startingViewName, sceneFactory, controller)
        {
            _areScreenSettingsPreCalculated = false;
            _defaultScreenSize = defaultGameSize;
        }

        public MainGame(string title, string startingViewName, Display screenSettings, SceneFactory sceneFactory, IController controller)
            : this(title, startingViewName, sceneFactory, controller)
        {
            _areScreenSettingsPreCalculated = true;
            _display = screenSettings;
        }

        private MainGame(string title, string startingViewName, SceneFactory sceneFactory, IController controller)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _startingViewName = startingViewName;
            _sceneFactory = sceneFactory;
            _controller = controller;
            _metrics = new Metrics();
            Window.Title = title;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            _sprites = new SpriteBatch(GraphicsDevice);
            Resources.Init(this);
            Hack.TheGame = this;
            Input.SetController(_controller);
            base.Initialize();
            _black = new RectangleTexture(new Rectangle(new Point(0, 0), new Point(1, 1)), Color.Black).Create();
            InitDisplayIfNeeded();
            World.Init(this, this, _sprites, _display);
            UI.Init(this, _sprites, _display);
            _display.Apply(_graphics);
            Window.Position = new Point(0, 0);
        }

        private void InitDisplayIfNeeded()
        {
            if (!_areScreenSettingsPreCalculated)
            {
                var widthScale = (float)GraphicsDevice.DisplayMode.Width / _defaultScreenSize.Width;
                var heightScale = (float)GraphicsDevice.DisplayMode.Height / _defaultScreenSize.Height;
                var scale = widthScale > heightScale ? heightScale : widthScale;
                _display = new Display((int)Math.Round(_defaultScreenSize.Width * scale), (int)Math.Round(_defaultScreenSize.Height * scale),
                    true, scale);
            }
            CurrentDisplay.Init(_display);
        }

        protected override void LoadContent()
        {
            NavigateTo(_startingViewName);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            CheckForEscape();
            _metrics.Update(gameTime.ElapsedGameTime);
            _controller.Update(gameTime.ElapsedGameTime);
            _currentScene?.Update(gameTime.ElapsedGameTime);
            new Physics().Resolve();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _sprites.Begin(SpriteSortMode.Deferred, null, SamplerState.AnisotropicClamp);
            World.DrawBackgroundColor(Color.Black);
            _currentScene?.Draw();
            _metrics.Draw(Transform2.Zero);
            HideExternals();
            _sprites.End();
            base.Draw(gameTime);
        }

        private void HideExternals()
        {
            _sprites.Draw(_black, new Rectangle(new Point(_display.GameWidth, 0),
                new Point(_display.ProgramWidth - _display.GameWidth, _display.ProgramHeight)), Color.Black);
            _sprites.Draw(_black, new Rectangle(new Point(0, _display.GameHeight),
                new Point(_display.ProgramWidth, _display.ProgramHeight - _display.GameHeight)), Color.Black);
        }

        public void NavigateTo(string sceneName)
        {
            var scene = _sceneFactory.Create(sceneName);
            scene.Init();
            _currentScene = scene;
        }

        // TODO: This is only for development. Remove this when re're ready to release to production!!
        private void CheckForEscape()
        {
#if DEBUG  
            var state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.Escape))
                Hack.TheGame.Exit();
#endif
        }
    }
}

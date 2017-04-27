using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
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

        private SpriteBatch _sprites;
        private IScene _currentScene;

        private GraphicsDeviceManager manager;
        private bool areScreenSettingsPreCalculated;
        private ScreenSettings settings;
        private Size2 defaultScreenSize;

        public MainGame(string startingViewName, int defaultWidth, int defaultHeight, SceneFactory sceneFactory, IController controller)
            : this(startingViewName, sceneFactory, controller)
        {
            areScreenSettingsPreCalculated = false;
            defaultScreenSize = new Size2(defaultWidth, defaultHeight);
            //var g = new GraphicsDeviceManager(this);
            //var hostWidth = GraphicsDevice.DisplayMode.Width;
            //var hostHeight = GraphicsDevice.DisplayMode.Height;
            //new ScreenSettings(800, 450, false, 0.5f).Apply(g);
        }
        public MainGame(string startingViewName, ScreenSettings screenSettings, SceneFactory sceneFactory, IController controller)
            : this(startingViewName, sceneFactory, controller)
        {
            areScreenSettingsPreCalculated = true;
            settings = screenSettings;
        }
        private MainGame(string startingViewName, SceneFactory sceneFactory, IController controller)
        {
            manager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _startingViewName = startingViewName;
            _sceneFactory = sceneFactory;
            _controller = controller;
            _metrics = new Metrics();
        }

        protected override void Initialize()
        {
            this.Window.Title = "Planet or Die!";
            IsMouseVisible = true;
            Resources.Init(this);
            _sprites = new SpriteBatch(GraphicsDevice);
            Hack.TheGame = this;
            Input.SetController(_controller);
            World.Init(this, this, _sprites);
            UI.Init(this, _sprites);
            base.Initialize();
            if (areScreenSettingsPreCalculated)
                settings.Apply(manager);
            else
            {
                var hostWidth = GraphicsDevice.DisplayMode.Width;
                var hostHeight = GraphicsDevice.DisplayMode.Height;
                var widthScale = (float)hostWidth / defaultScreenSize.Width;
                var heightScale = (float)hostHeight / defaultScreenSize.Height;
                var scale = widthScale > heightScale ? heightScale : widthScale;
                new ScreenSettings((int)Math.Round(defaultScreenSize.Width * scale), (int)Math.Round(defaultScreenSize.Height * scale),
                    false, scale).Apply(manager);
            }
            manager.ApplyChanges();
            Hack.TheGame.Window.Position = new Point(0, 0);
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
            _sprites.End();
            base.Draw(gameTime);
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

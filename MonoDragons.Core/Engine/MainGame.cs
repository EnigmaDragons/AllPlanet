using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

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

        public MainGame(string startingViewName, ScreenSettings screenSettings, SceneFactory sceneFactory, IController controller)
        {
            screenSettings.Apply(new GraphicsDeviceManager(this));
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

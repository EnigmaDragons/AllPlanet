using System;
using AllPlanet.Argument;
using AllPlanet.Debate;
using AllPlanet.Player;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using Microsoft.Xna.Framework;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private ClickUI _clickUi;
        private ArgumentLearnedUI _player;
        private DebatePresentation _debate;

        public void Init()
        {
            _player = new ArgumentLearnedUI();
            _debate = new DebatePresentation();
            _clickUi = new ClickUI();
            _clickUi.Add(_debate.Branch);
            _clickUi.Add(_player.Branch);
            _clickUi.Add(new SimpleClickable(new Rectangle(new Point(0, 0), new Point(1600, 900)), () => World.Publish(new AdvanceRequested())));
            World.Publish(new PresentationStarted());
            World.Publish(new ReadyForSegue("lava"));
        }

        public void Update(TimeSpan delta)
        {
            _debate.Update(delta);
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            _debate.Draw(Transform2.Zero);
            _player.Draw(Transform2.Zero);
        }
    }
}

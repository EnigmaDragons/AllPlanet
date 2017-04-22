using System;
using AllPlanet.Argument;
using AllPlanet.Debate;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using AllPlanet.Crowds;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private DebatePresentation _debatePresentation;
        private Crowd _crowd;

        public void Init()
        {
            _crowd = new Crowd();
            _debatePresentation = new DebatePresentation();
            World.Publish(new PresentationStarted());
            World.Publish(new ReadyForSegue("lava"));
        }

        public void Update(TimeSpan delta)
        {
            _debatePresentation.Update(delta);
        }

        public void Draw()
        {
            _debatePresentation.Draw(Transform2.Zero);
        }
    }
}

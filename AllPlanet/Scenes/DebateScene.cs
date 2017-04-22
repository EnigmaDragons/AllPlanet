using System;
using AllPlanet.Debate;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private DebateCamera _debateCamera;

        public void Init()
        {
            _debateCamera = new DebateCamera();
        }

        public void Update(TimeSpan delta)
        {
            _debateCamera.Update(delta);
        }

        public void Draw()
        {
            _debateCamera.Draw(Transform2.Zero);
        }
    }
}

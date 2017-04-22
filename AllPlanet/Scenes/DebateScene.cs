using System;
using AllPlanet.Crowd;
using AllPlanet.Debate;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private StageUI _stageUi;
        private CrowdUI _crowdUi;
        private bool _shouldShowCrowd;

        public void Init()
        {
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            Input.On(Control.A, () => _shouldShowCrowd = !_shouldShowCrowd);
        }

        public void Update(TimeSpan delta)
        {
            _crowdUi.Update(delta);
            _stageUi.Update(delta);
        }

        public void Draw()
        {
            if (_shouldShowCrowd)
                _crowdUi.Draw(Transform2.Zero);
            else
                _stageUi.Draw(Transform2.Zero);
        }
    }
}

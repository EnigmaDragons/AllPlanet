using System;
using AllPlanet.Argument;
using AllPlanet.Crowd;
using AllPlanet.Debate;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public sealed class DebateScene : IScene
    {
        private RefutationUI _refutation;
        private StageUI _stageUi;
        private CrowdUI _crowdUi;
        private bool _shouldShowCrowd;

        public void Init()
        {
            _refutation = new RefutationUI(new Segue("lava"));
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            Input.On(Control.A, () => _shouldShowCrowd = !_shouldShowCrowd);
        }

        public void Update(TimeSpan delta)
        {
            _refutation.Update(delta);
            _crowdUi.Update(delta);
            _stageUi.Update(delta);
        }

        public void Draw()
        {
            if (_shouldShowCrowd)
                _crowdUi.Draw(Transform2.Zero);
            else
            {
                _stageUi.Draw(Transform2.Zero);
                _refutation.Draw(Transform2.Zero);
            }
        }
    }
}

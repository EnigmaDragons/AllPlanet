using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllPlanet.Argument;
using AllPlanet.Crowd;
using AllPlanet.Planet;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Debate
{
    public class DebateCamera : IVisualAutomaton
    {
        private readonly RefutationUI _refutation;
        private readonly StageUI _stageUi;
        private readonly CrowdUI _crowdUi;
        private int _remainingShowCrowd;
        private bool _shouldShowCrowd;

        public DebateCamera()
        {
            _refutation = new RefutationUI(new Segue("lava"));
            _stageUi = new StageUI();
            _crowdUi = new CrowdUI();
            World.Subscribe(EventSubscription.Create<PlanetResponds>(PlanetSays, this));
            World.Subscribe(EventSubscription.Create<OpponentResponds>(OpponentSays, this));
            World.Subscribe(EventSubscription.Create<CrowdResponds>(CrowdSays, this));
        }

        private void CrowdSays(CrowdResponds obj)
        {
            _shouldShowCrowd = true;
            _remainingShowCrowd = 3000;
            if (obj.Expression.Equals(CrowdExpression.Boo))
                Audio.PlaySound("crowd-boo");
            if (obj.Expression.Equals(CrowdExpression.Cheer))
                Audio.PlaySound("crowd-cheering");

        }

        private void OpponentSays(OpponentResponds obj)
        {
            // TODO: Implement
        }

        private void PlanetSays(PlanetResponds obj)
        {
            // TODO: Implement
        }

        public void Update(TimeSpan delta)
        {
            if (_remainingShowCrowd > 0)
                _remainingShowCrowd -= (int)delta.TotalMilliseconds;
            if (_remainingShowCrowd <= 0)
                _shouldShowCrowd = false;

            _refutation.Update(delta);
            _crowdUi.Update(delta);
            _stageUi.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
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

using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Debate
{
    public class ModeratorChar : IVisualAutomaton
    {
        private string Image => "Characters/mc-" + _exp.ToString().ToLower();
        private ModeratorExpression _exp = ModeratorExpression.Mic;
        private bool _isLeaving;
        private Transform2 _transform;

        public ModeratorChar(Transform2 transform)
        {
            _transform = transform;
            World.Subscribe(EventSubscription.Create<ModeratorSays>(x => _exp = x.Expression, this));
        }

        public void LeaveStage()
        {
            _isLeaving = true;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            var t = _transform + parentTransform;
            World.Draw(Image, t.ToRectangle());
        }
    }
}

using System;
using AllPlanet.Moderator;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace AllPlanet.Debate
{
    public class ModeratorChar : IVisualAutomaton
    {
        private string Image => "Characters/mc-" + _exp.ToString().ToLower();
        private ModeratorExpression _exp = ModeratorExpression.Mic;
        private bool _isLeaving;
        private Transform2 _transform;
        private int _xOffset;

        public ModeratorChar(Transform2 transform)
        {
            _transform = transform;
            World.Subscribe(EventSubscription.Create<ModeratorSays>(x => _exp = x.Expression, this));
            World.Subscribe(EventSubscription.Create<ModeratorLeaves>(x => LeaveStage(), this));
        }

        public void LeaveStage()
        {
            _isLeaving = true;
            _exp = ModeratorExpression.Mic;
            World.Unsubscribe(this);
        }

        public void Update(TimeSpan delta)
        {
            if (_isLeaving)
                _xOffset += 10;
            if (_xOffset > 1600)
                _isLeaving = false;
        }

        public void Draw(Transform2 parentTransform)
        {
            var t = (_transform + parentTransform) + new Vector2(_xOffset, 0);
            World.Draw(Image, t.ToRectangle());
        }
    }
}

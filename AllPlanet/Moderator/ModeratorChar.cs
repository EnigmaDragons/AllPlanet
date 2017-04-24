using System;
using AllPlanet.Moderator;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;
using AllPlanet.Argument;

namespace AllPlanet.Debate
{
    public class ModeratorChar : IVisualAutomaton
    {
        private string Image => "Characters/mc-" + _exp.ToString().ToLower();
        private ModeratorExpression _exp = ModeratorExpression.Mic;
        private bool _isEntering = false;
        private bool _isLeaving = false;
        private Transform2 _transform;
        private int _xOffset;

        public ModeratorChar(Transform2 transform)
        {
            _xOffset = - (int)Math.Ceiling(transform.Location.X + transform.Size.Width);
            _transform = transform;
            World.Subscribe(EventSubscription.Create<ModeratorEnters>(x => EnterStage(), this));
            World.Subscribe(EventSubscription.Create<ModeratorSays>(x => _exp = x.Expression, this));
            World.Subscribe(EventSubscription.Create<ModeratorLeaves>(x => LeaveStage(), this));
        }

        public void EnterStage()
        {
            _xOffset = -(int)Math.Ceiling(_transform.Location.X + _transform.Size.Width);
            _isEntering = true;
            _exp = ModeratorExpression.Mic;
        }

        public void LeaveStage()
        {
            _isLeaving = true;
            _exp = ModeratorExpression.Mic;
        }

        public void Update(TimeSpan delta)
        {
            if (_isEntering || _isLeaving)
                _xOffset += 10;
            if (_isEntering && _xOffset > -1)
            {
                World.Publish(new AdvanceArgument());
                _isEntering = false;
                _xOffset = 0;
            }
            if (_isLeaving && _xOffset + _transform.Location.X > 1600)
            {
                World.Publish(new AdvanceArgument());
                _isLeaving = false;
            }
        }

        public void Draw(Transform2 parentTransform)
        {
            var t = (_transform + parentTransform) + new Vector2(_xOffset, 0);
            World.Draw(Image, t.ToRectangle());
        }
    }
}

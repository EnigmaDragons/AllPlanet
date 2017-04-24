using System;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace AllPlanet.Opponent
{
    public class Scientist3 : ICharacter
    {
        private OpponentExpression _exp = OpponentExpression.Bored;
        private readonly string _imgPre = "Characters/sci3-";
        private string Image => _imgPre + _exp.ToString().ToLower();
        
        private bool _isEntering = false;
        private bool _isLeaving = false;
        private Transform2 _transform;
        private int _xOffset;

        public Scientist3(Transform2 transform)
        {
            _transform = transform + new Vector2(0, 0);
            _xOffset = (int)Math.Ceiling(1610 - _transform.Location.X);
            World.Subscribe(EventSubscription.Create<StatementChanged>((e) => StatementChanged(e.Statement.Expression), this));
            World.Subscribe(EventSubscription.Create<OpponentResponds>((e) => StatementChanged(e.Expression), this));
            World.Subscribe(EventSubscription.Create<OpponentEnters>((e) => EnterStage(), this));
            World.Subscribe(EventSubscription.Create<OpponentLeaves>((e) => LeaveStage(), this));
        }

        private void StatementChanged(OpponentExpression obj)
        {
            _exp = obj;
        }

        public void SkipAnimation()
        {
            if (_isEntering)
            {
                _xOffset = 0;
                _isEntering = false;
                World.Publish(new AdvanceArgument());
            }
            else if (_isLeaving)
            {
                _xOffset = (int)Math.Ceiling(1610 - _transform.Location.X);
                _isLeaving = false;
                World.Publish(new AdvanceArgument());
            }
        }

        public void EnterStage()
        {
            _xOffset = (int)Math.Ceiling(1610 - _transform.Location.X);
            _isEntering = true;
            _exp = OpponentExpression.Bored;
        }

        public void LeaveStage()
        {
            _isLeaving = true;
            _exp = OpponentExpression.Worried;
        }

        public void Update(TimeSpan delta)
        {
            if (_isEntering)
            {
                _xOffset -= 8;
                if (_xOffset < 1)
                {
                    World.Publish(new AdvanceArgument());
                    _isEntering = false;
                    _xOffset = 0;
                }
            }
            else if (_isLeaving)
            {
                _xOffset += 8;
                if (_xOffset + _transform.Location.X > 1610)
                {
                    World.Publish(new AdvanceArgument());
                    _isLeaving = false;
                }
            }
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(Image, parentTransform.Location + _transform.Location + new Vector2(_xOffset, 0));
        }

        public void Dispose()
        {
            World.Unsubscribe(this);
        }
    }
}

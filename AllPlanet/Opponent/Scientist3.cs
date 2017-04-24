using System;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Audio;

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

        private Timer _expTimer;
        private Timer _seqTimer;

        private int _phase = 0;
        private bool _isAlive = true;
        private bool _isExploding;
        private int _explodingFrame = 1;

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
                _phase = 10;
                _isAlive = false;
                _isExploding = false;
                _explodingFrame = 9;
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
            _exp = OpponentExpression.Proud;
            _expTimer = new Timer(UpdateExpFrame, 90);
            _seqTimer = new Timer(Next, 500);
        }

        private void UpdateExpFrame()
        {
            if (!_isExploding)
                return;
            _explodingFrame++;
            if (_explodingFrame > 8)
                _isExploding = false;
        }

        private void Next()
        {
            _phase++;
            if (_phase == 2)
            {
                _isExploding = true;
                Audio.PlaySound("explosion", 0.7f);
            }
            if (_phase == 3)
                _isAlive = false;
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
                _expTimer.Update(delta);
                _seqTimer.Update(delta);
                /*_xOffset += 8;
                if (_xOffset + _transform.Location.X > 1610)
                {
                    World.Publish(new AdvanceArgument());
                    _isLeaving = false;
                }*/
            }
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_isAlive)
                World.Draw(Image, parentTransform.Location + _transform.Location + new Vector2(_xOffset, 0));
            if (_isExploding)
                World.Draw($"Anim/explosion{_explodingFrame}", new Rectangle((parentTransform.Location + _transform.Location + new Vector2(_xOffset - 235, -50)).ToPoint(), (new Vector2(550, 450) * 1.3f).ToPoint()));
        }

        public void Dispose()
        {
            World.Unsubscribe(this);
        }
    }
}

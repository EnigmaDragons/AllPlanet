using System;
using AllPlanet.Argument;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Opponent
{
    public class BusinessMan : IVisualAutomaton
    {
        private OpponentExpression _exp = OpponentExpression.Bored;
        private readonly string _imgPre = "Characters/business-";
        private string Image => _imgPre + _exp.ToString().ToLower();

        private readonly Vector2 _offset;

        public BusinessMan()
        {
            _offset = new Vector2(35, -15);
            World.SubscribeForScene(EventSubscription.Create<StatementChanged>(StatementChanged, this));
        }

        private void StatementChanged(StatementChanged obj)
        {
            _exp = obj.Statement.Expression;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(Image, parentTransform.Location + _offset);
        }
    }
}

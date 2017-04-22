using System;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Opponent
{
    public class Scientist3 : IVisualAutomaton
    {
        private OpponentExpression _exp = OpponentExpression.Bored;
        private readonly string _imgPre = "Characters/sci3-";
        private string Image => _imgPre + _exp.ToString().ToLower();

        public Scientist3()
        {
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
            World.Draw(Image, parentTransform.Location);
        }
    }
}

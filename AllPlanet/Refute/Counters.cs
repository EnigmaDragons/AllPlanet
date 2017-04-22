using AllPlanet.Crowd;
using MonoDragons.Core.Engine;
using System;

namespace AllPlanet.Refute
{
    public class Counter
    {
        public string Statement;
        private CrowdExpression _expression;
        private string _argumentPointToNavigateTo;

        public Counter(string statement, CrowdExpression expression, string argumentPointToNavigateTo)
        {
            Statement = statement;
            _expression = expression;
            _argumentPointToNavigateTo = argumentPointToNavigateTo;
        }

        public void Go()
        {
            World.Publish(new CrowdExpresses(_expression));
            World.Publish(new Segue(_argumentPointToNavigateTo));
        }
    }
}
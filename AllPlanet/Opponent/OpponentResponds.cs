using AllPlanet.Opponent;

namespace AllPlanet.Argument
{
    public class OpponentResponds
    {
        public string Statement { get; }
        public OpponentExpression Expression { get; }

        public OpponentResponds(string statement, OpponentExpression expression)
        {
            Statement = statement;
            Expression = expression;
        }
    }
}

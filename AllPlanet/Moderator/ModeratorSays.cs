
namespace AllPlanet.Debate
{
    public class ModeratorSays
    {
        public string Statement { get; }
        public ModeratorExpression Expression { get; }

        public ModeratorSays(ModeratorExpression expression, string statement)
        {
            Statement = statement;
            Expression = expression;
        }
    }
}

using AllPlanet.Refute;

namespace AllPlanet.Argument
{
    public class ArgumentPoint
    {
        public Statement[] Statements;

        public ArgumentPoint(params Statement[] statements)
        {
            Statements = statements;
        }
    }
}

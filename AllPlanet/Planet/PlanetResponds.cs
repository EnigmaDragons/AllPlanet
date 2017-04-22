namespace AllPlanet.Planet
{
    public class PlanetResponds
    {
        public string Statement { get; }
        public PlanetExpression Expression { get; }

        public PlanetResponds(string statement, PlanetExpression expression)
        {
            Statement = statement;
            Expression = expression;
        }
    }
}

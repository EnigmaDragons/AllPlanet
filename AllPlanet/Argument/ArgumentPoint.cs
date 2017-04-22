using AllPlanet.Refute;
using MonoDragons.Core.Engine;
using System;

namespace AllPlanet.Argument
{
    public class ArgumentPoint
    {
        public Statement[] Statements;
        public Statement CurrentStatement;
        public bool HasNext => indexer < Statements.Length - 1;
        public bool HasPrior => indexer > 0;
        private int indexer;

        public ArgumentPoint(Statement[] statements)
        {
            Statements = statements;
            CurrentStatement = Statements[0];
            indexer = 0;
        }

        public void Next()
        {
            indexer = Math.Max(indexer + 1, Statements.Length - 1);
            CurrentStatement = Statements[indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Prior()
        {
            indexer = Math.Min(indexer - 1, 0);
            CurrentStatement = Statements[indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Reset()
        {
            indexer = 0;
            CurrentStatement = Statements[0];
            World.Publish(new StatementChanged(CurrentStatement));
        }
    }
}

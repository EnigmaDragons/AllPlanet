using MonoDragons.Core.Engine;
using System;

namespace AllPlanet.Argument
{
    public class ArgumentPoint
    {
        public string Name { get; }
        public Statement[] Statements { get; }
        public Statement CurrentStatement { get; private set; }
        public bool HasNext => _indexer < Statements.Length - 1;
        public bool HasPrior => _indexer > 0;
        private int _indexer;

        public ArgumentPoint(string name, params Statement[] statements)
        {
            Name = name;
            Statements = statements;
            CurrentStatement = Statements[0];
            _indexer = 0;
        }

        public void Next()
        {
            _indexer = Math.Min(_indexer + 1, Statements.Length - 1);
            CurrentStatement = Statements[_indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Prior()
        {
            _indexer = Math.Max(_indexer - 1, 0);
            CurrentStatement = Statements[_indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Reset()
        {
            _indexer = 0;
            CurrentStatement = Statements[0];
            World.Publish(new StatementChanged(CurrentStatement));
        }
    }
}

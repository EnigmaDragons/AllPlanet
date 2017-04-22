using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using AllPlanet.Player;
using MonoDragons.Core.EventSystem;

namespace AllPlanet.Argument
{
    public class ArgumentPoint
    {
        public static ArgumentPoint None = new ArgumentPoint(new List<object>(), "None",
            new Statement("Empty", Opponent.OpponentExpression.Bored, new RefuteOption(ArgumentType.AgreeAndAmplify, "")));

        public string Name { get; }
        public Statement CurrentStatement { get; private set; }
        public bool HasNext => _indexer < _statements.Length - 1;
        public bool HasPrior => _indexer > 0;

        private List<object> _opening;
        private int _openingIndex;
        private Statement[] _statements;
        private int _indexer;

        public ArgumentPoint(List<object> opening, string name, params Statement[] statements)
        {
            Name = name;
            _statements = statements;
            _opening = opening;
            _openingIndex = 0;
            CurrentStatement = _statements[0];
            _indexer = 0;
        }

        public void Start()
        {
            if (_openingIndex != _opening.Count)
            {
                World.Subscribe(EventSubscription.Create<AdvanceRequested>(x => Advance(), this));
                Advance();
            }
            Reset();
        }

        private void Advance()
        {
            if (_openingIndex != _opening.Count)
            {
                World.Unsubscribe(this);
                Reset();
            }
            else
            {
                var nextEvent = _opening[_openingIndex];
                _openingIndex++;
                World.Publish(nextEvent);
            }
        }

        public void Next()
        {
            _indexer = Math.Min(_indexer + 1, _statements.Length - 1);
            CurrentStatement = _statements[_indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Prior()
        {
            _indexer = Math.Max(_indexer - 1, 0);
            CurrentStatement = _statements[_indexer];
            World.Publish(new StatementChanged(CurrentStatement));
        }

        public void Reset()
        {
            _indexer = 0;
            CurrentStatement = _statements[0];
            World.Publish(new RefutationStarted());
            World.Publish(new StatementChanged(CurrentStatement));
        }
    }
}

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

        private List<object> _presentation;
        private int _presentingIndex;
        private Statement[] _statements;
        private int _indexer;

        public ArgumentPoint(List<object> presentation, string name, params Statement[] statements)
        {
            Name = name;
            _statements = statements;
            _presentation = presentation;
            _presentingIndex = 0;
            CurrentStatement = _statements[0];
            _indexer = 0;
        }

        public void Start()
        {
            if (_presentingIndex != _presentation.Count)
            {
                World.Publish(new ModeChanged(Mode.Presentation));
                World.Subscribe(EventSubscription.Create<AdvanceArgument>(x => Advance(), this));
                Advance();
            }
            else
                Reset();
        }

        private void Advance()
        {
            if (_presentingIndex == _presentation.Count)
            {
                World.Unsubscribe(this);
                Reset();
            }
            else
            {
                var nextEvent = _presentation[_presentingIndex];
                _presentingIndex++;
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
            World.Publish(new ModeChanged(Mode.Refutation));
            World.Publish(new StatementChanged(CurrentStatement));
        }
    }
}

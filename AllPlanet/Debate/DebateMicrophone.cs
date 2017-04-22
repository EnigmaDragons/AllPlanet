using System;
using AllPlanet.Argument;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Debate
{
    public class DebateMicrophone : IVisualAutomaton
    {
        private readonly SpeechUI _speech;

        public DebateMicrophone()
        {
            _speech = new SpeechUI();
            World.Subscribe(EventSubscription.Create<StatementChanged>(ChangeStatement, this));
        }

        public void Update(TimeSpan delta)
        {
            _speech.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _speech.Draw(parentTransform);
        }

        public void PlanetSays(string message)
        {
            _speech.Show(message, Side.Left);
        }

        public void OpponentSays(string message)
        {
            _speech.Show(message, Side.Right);
        }

        private void ChangeStatement(StatementChanged obj)
        {
            OpponentSays(obj.Statement.Message);
        }
    }
}

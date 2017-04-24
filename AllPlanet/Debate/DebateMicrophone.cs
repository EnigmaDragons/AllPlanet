using System;
using AllPlanet.Argument;
using AllPlanet.Moderator;
using AllPlanet.Planet;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using AllPlanet.Opponent;

namespace AllPlanet.Debate
{
    public class DebateMicrophone : IVisualAutomaton
    {
        private readonly SpeechUI _speech;
        private bool _someoneIsSpeaking;

        public DebateMicrophone()
        {
            _speech = new SpeechUI();
            World.Subscribe(EventSubscription.Create<StatementChanged>(ChangeStatement, this));
            World.Subscribe(EventSubscription.Create<PlanetResponds>(x => PlanetSays(x.Statement), this));
            World.Subscribe(EventSubscription.Create<OpponentResponds>(x => OpponentSays(x.Statement), this));
            World.Subscribe(EventSubscription.Create<ModeratorSays>(x => ModeratorSays(x.Statement), this));
            World.Subscribe(EventSubscription.Create<ModeratorEnters>(x => Silence(), this));
            World.Subscribe(EventSubscription.Create<ModeratorLeaves>(x => Silence(), this));
            World.Subscribe(EventSubscription.Create<OpponentEnters>(x => Silence(), this));
            World.Subscribe(EventSubscription.Create<OpponentLeaves>(x => Silence(), this));
        }

        private void Silence()
        {
            _someoneIsSpeaking = false;
        }

        public void Update(TimeSpan delta)
        {
            _speech.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if(_someoneIsSpeaking)
                _speech.Draw(parentTransform);
        }

        public void PlanetSays(string message)
        {
            _speech.Show(message, Side.Left);
            _someoneIsSpeaking = true;
        }

        public void OpponentSays(string message)
        {
            _speech.Show(message, Side.Right);
            _someoneIsSpeaking = true;
        }

        public void ModeratorSays(string message)
        {
            _speech.Show(message, Side.Center);
            _someoneIsSpeaking = true;
        }

        private void ChangeStatement(StatementChanged obj)
        {
            OpponentSays(obj.Statement.Message);
        }
    }
}

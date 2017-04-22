using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Characters
{
    public class Scientist3 : IVisualAutomaton
    {
        private OpponentState _state = OpponentState.Bored;
        private readonly string _imgPre = "Characters/sci3-";
        private string Image => _imgPre + _state.ToString().ToLower();

        public Scientist3()
        {
            World.SubscribeForScene(EventSubscription.Create<OpponentStateChanged>(StateChanged, this));
        }

        private void StateChanged(OpponentStateChanged obj)
        {
            _state = obj.State;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(Image, parentTransform.Location);
        }
    }
}

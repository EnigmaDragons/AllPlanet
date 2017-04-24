using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Planet
{
    public sealed class PlanetChar : IVisualAutomaton
    {
        private PlanetExpression _exp = PlanetExpression.Thinking;
        private readonly string _imgPre = "Characters/planet-";
        private string Image => _imgPre + _exp.ToString().ToLower();

        private readonly Transform2 _transform = new Transform2(new Size2(380, 190));

        public PlanetChar()
        {
            World.Subscribe(EventSubscription.Create<PlanetResponds>(PlanetResponds, this));
        }

        private void PlanetResponds(PlanetResponds obj)
        {
            _exp = obj.Expression;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            var t = _transform + parentTransform;
            World.Draw(Image, t.ToRectangle());
        }
    }
}

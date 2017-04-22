using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Debate
{
    public class StageCurtain : IVisualAutomaton
    {
        private readonly string _curtain = "Backdrops/curtain";

        private int _curtainHeight;
        private bool _shouldBeUp;

        public void Update(TimeSpan delta)
        {
            if (_shouldBeUp && _curtainHeight > -900)
                _curtainHeight -= 10;
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.DrawCenteredWithOffset(_curtain, Sizes.Backdrop, new Vector2(0, _curtainHeight));
        }

        public void Raise()
        {
            _shouldBeUp = true;
        }
    }
}

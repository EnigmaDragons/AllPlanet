using System;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.EventSystem;
using AllPlanet.Argument;

namespace AllPlanet.Debate
{
    public sealed class StageUI : IVisualAutomaton
    {
        private readonly BobbingEffect bobbingEffect = new BobbingEffect(25,  0, 0,  1, 0,  1, 1,  1, 2,  1, 3,  0, 3,  -1, 3,  -1, 2,  -1, 1,  -1, 0);
        private ICharacter _opponent;
        private readonly IVisualAutomaton _planet = new PlanetChar();

        public StageUI()
        {
            _opponent = new BusinessMan(new Transform2(new Vector2(950, 320), new Size2(300, 450)));
            _opponent.EnterStage();
            _opponent.SkipAnimation();
            World.Subscribe(EventSubscription.Create<ChangeOpponents>(ChangeOpponents, this));
        }

        private void ChangeOpponents(ChangeOpponents opponent)
        {
            _opponent.Dispose();
            _opponent = CharacterFactory.Create(opponent.Name, new Transform2(new Vector2(950, 320), new Size2(300, 450)));
            World.Publish(new AdvanceArgument());
        }

        public void Update(TimeSpan delta)
        {
            _opponent.Update(delta);
            _planet.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            var effect = bobbingEffect.Effect;
            UI.DrawCentered("Backdrops/stage", Sizes.Backdrop);
            _planet.Draw(new Transform2(new Vector2(320, 310) + effect));
            _opponent.Draw(new Transform2(effect));
            World.Draw("Props/podium-l", new Rectangle(460, 500, 150, 300));
            World.Draw("Props/podium-r", new Rectangle(940, 500, 150, 300));
            World.Draw("Backdrops/curtain-front", new Vector2(0, 0));
        }
    }
}

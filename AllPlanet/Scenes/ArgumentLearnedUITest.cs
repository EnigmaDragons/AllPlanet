
using System;
using AllPlanet.Argument;
using AllPlanet.Planet;
using AllPlanet.Player;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet.Scenes
{
    public class ArgumentLearnedUITest : IScene
    {
        private ArgumentLearnedUI _ui;

        public void Init()
        {
            _ui = new ArgumentLearnedUI();
            World.Publish(new ArgumentLearned("Sample Name", "lorem ipsum 1iohiosndfqwkerkqwerqwerqwer"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            _ui.Draw(Transform2.Zero);
        }
    }
}

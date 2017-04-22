using AllPlanet.Debate;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System;

namespace AllPlanet.Scenes
{
    public class TestScene : IScene
    {
        private ClickUI _clickUi;

        public void Init()
        {
            // ClickUI.GetElement Is Private
            /*_clickUi = new ClickUI();
            var b1 = new ClickUIBranch("name", 1);
            _clickUi.Add(b1);
            var e1 = new SimpleClickable(new Rectangle(200, 200, 100, 100), () => { });
            b1.Add(e1);
            if (_clickUi.GetElement(new Point(250, 250)) != e1)
                throw new Exception();
            var e2 = new SimpleClickable(new Rectangle(200, 200, 100, 100), () => { }, 2);
            b1.Add(e2);
            if (_clickUi.GetElement(new Point(125, 125)) != e2)
                throw new Exception();
            var b2 = new ClickUIBranch("named", 2, 2);
            _clickUi.Add(b2);
            var e3 = new SimpleClickable(new Rectangle(200, 200, 100, 100), () => { });
            b2.Add(e3);
            if (_clickUi.GetElement(new Point(125, 125)) != e3)
                throw new Exception();
            _clickUi.Scale = 2;
            if (_clickUi.GetElement(new Point(65, 65)) != e3)
                throw new Exception();*/
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
        }
    }
}

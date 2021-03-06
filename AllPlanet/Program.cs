﻿using System;
using System.Collections.Generic;
using AllPlanet.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.EngimaDragons;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Navigation;
using MonoDragons.Core.PhysicsEngine;

namespace AllPlanet
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame("Planet or Die!", "Logo", new Size2(1600, 900), CreateSceneFactory(), CreateKeyboardController()))
                game.Run();
        }

        private static IController CreateKeyboardController()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Enter, Control.Start },
                { Keys.Z, Control.A },
                { Keys.X, Control.B },
                { Keys.C, Control.X },
                { Keys.V, Control.Y },
                { Keys.Space, Control.A }
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "Logo", () => new FadingInScene(new LogoScene()) },
                { "Debate", () => new DebateScene() },
                { "Speech", () => new SpeechUITest() },
                { "Test", () => new TestScene() },
                { "Intro", () => new Intro() },
                { "YouLose", () => new YouLose() },
                { "YouWin", () => new DebateAward() },
                { "MainMenu", () => new MainMenu() },
                { "Credits", () => new Credits() },
            });
        }
    }
#endif
}

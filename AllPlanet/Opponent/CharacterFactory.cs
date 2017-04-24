using MonoDragons.Core.PhysicsEngine;
using System;
using System.Collections.Generic;

namespace AllPlanet.Opponent
{
    public static class CharacterFactory
    {
        private static Dictionary<string, Func<Transform2, ICharacter>> _arguments = new Dictionary<string, Func<Transform2, ICharacter>>
        {
            { "BusinessMan", (t) => new BusinessMan(t) },
            { "Scientist3", (t) => new Scientist3(t) },
        };

        public static bool Exists(string name)
        {
            return _arguments.ContainsKey(name);
        }

        public static ICharacter Create(string name, Transform2 transform)
        {
            return _arguments[name](transform);
        }
    }
}

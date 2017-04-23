using AllPlanet.Argument;
using System;
using System.Linq;

namespace AllPlanet.Player
{
    public class ArgumentLearned
    {
        public string Name { get; }
        public string Desc { get; }

        public ArgumentLearned(ArgumentType type, string desc)
        {
            Name = string.Join("", type.ToString().Select((c) => char.IsUpper(c) ? " " + c: "" + c)).Remove(0, 1);
            Desc = desc;
        }
    }
}

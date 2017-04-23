using System.Collections.Generic;
using AllPlanet.Argument.Concrete;

namespace AllPlanet.Argument
{
    public static class ArgumentPointFactory
    {
        private static Dictionary<string, ArgumentPoint> _arguments = new Dictionary<string, ArgumentPoint>
        {
            { LavaArgument.Argument.Name, LavaArgument.Argument },
            { PopsicleArgument.Argument.Name, PopsicleArgument.Argument },
            { NoMoonArgument.Argument.Name, NoMoonArgument.Argument },
            { MoonsAreNotGoodArgument.Argument.Name, MoonsAreNotGoodArgument.Argument },
        };

        public static ArgumentPoint Create(string name)
        {
            return _arguments[name];
        }
    }
}

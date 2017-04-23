using System.Collections.Generic;
using AllPlanet.Argument.Concrete;

namespace AllPlanet.Argument
{
    public static class ArgumentPointFactory
    {
        private static Dictionary<string, ArgumentPoint> _arguments = new Dictionary<string, ArgumentPoint>
        {
            { LavaArgument.Argument.Name, LavaArgument.Argument },
            { new PopsicleArgument().Argument.Name, new PopsicleArgument().Argument },
            { new NoMoonArgument().Argument.Name, new NoMoonArgument().Argument },
            { new MoonsAreNotGoodArgument().Argument.Name, new MoonsAreNotGoodArgument().Argument },
            { "next", LavaArgument.Argument },
        };

        public static ArgumentPoint Create(string name)
        {
            return _arguments[name];
        }
    }
}

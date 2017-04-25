using System.Collections.Generic;
using AllPlanet.Argument.Concrete;
using AllPlanet.Argument.Concrete.DrEmerson;
using AllPlanet.Argument.Concrete.Opponent2;

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
            { BornInLondonArgument.Argument.Name, BornInLondonArgument.Argument },
            { FakeCertificateArgument.Argument.Name, FakeCertificateArgument.Argument },
            { IllegalSmugglerArgument.Argument.Name, IllegalSmugglerArgument.Argument },
            { LegitScientistArgument.Argument.Name, LegitScientistArgument.Argument },
            { GravityIsTooWeakArgument.Argument.Name, GravityIsTooWeakArgument.Argument },
            { TooSmallArgument.Argument.Name, TooSmallArgument.Argument },
            { TooFarFromSunArgument.Argument.Name, TooFarFromSunArgument.Argument },
            { ExpertsSayArgument.Argument.Name, ExpertsSayArgument.Argument },
        };

        public static bool Exists(string name)
        {
            return _arguments.ContainsKey(name);
        }

        public static ArgumentPoint Create(string name)
        {
            return _arguments[name];
        }
    }
}

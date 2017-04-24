using System.Collections.Generic;
using AllPlanet.Closing.Concrete;

namespace AllPlanet.Closing
{
    public class ClosingArgumentFactory
    {
        private static Dictionary<string, ClosingArgument> _arguments = new Dictionary<string, ClosingArgument>
        {
            { ClosingArgument1.Argument.Name, ClosingArgument1.Argument },
            { QuintonRochefordClosing.Argument.Name, QuintonRochefordClosing.Argument },
        };

        public static bool Exists(string name)
        {
            return _arguments.ContainsKey(name);
        }

        public static ClosingArgument Create(string name)
        {
            return _arguments[name];
        }
    }
}
using System.Collections.Generic;
using AllPlanet.Closing.Concrete;

namespace AllPlanet.Closing
{
    public class ClosingArgumentFactory
    {
        private static Dictionary<string, ClosingArgument> _arguments = new Dictionary<string, ClosingArgument>
        {
            { ClosingArgument1.Argument.Name, ClosingArgument1.Argument },
        };

        public static ClosingArgument Create(string name)
        {
            return _arguments[name];
        }
    }
}
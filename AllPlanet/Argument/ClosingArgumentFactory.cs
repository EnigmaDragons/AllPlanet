using AllPlanet.Argument.Concrete;
using System.Collections.Generic;

namespace AllPlanet.Argument
{
    public class ClosingArgumentFactory
    {
        private static Dictionary<string, ClosingArgument> _arguments = new Dictionary<string, ClosingArgument>
        {
            { new ClosingArgument1().Argument.Name, new ClosingArgument1().Argument },
            { "nextClose", new ClosingArgument1().Argument },
        };

        public static ClosingArgument Create(string name)
        {
            return _arguments[name];
        }
    }
}
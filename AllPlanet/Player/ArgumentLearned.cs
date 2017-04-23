using AllPlanet.Argument;
using MonoDragons.Core.Text;

namespace AllPlanet.Player
{
    public class ArgumentLearned
    {
        public string Name { get; }
        public string Desc { get; }

        public ArgumentLearned(ArgumentType type, string desc)
        {
            Name = type.WithSpaces();
            Desc = desc;
        }
    }
}

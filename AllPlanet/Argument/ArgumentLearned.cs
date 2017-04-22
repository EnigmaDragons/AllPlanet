namespace AllPlanet.Argument
{
    public class ArgumentLearned
    {
        public ArgumentType Type;
        public string Description;

        public ArgumentLearned(ArgumentType type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}

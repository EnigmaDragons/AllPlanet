using AllPlanet.Crowd;
using AllPlanet.Opponent;
using AllPlanet.Refute;

namespace AllPlanet.Argument.Concrete
{
    public class GenericDiscreditResponse
    {
        public static RefuteOption Create(string argumentName)
        {
            return new RefuteOption(ArgumentType.Discredit, argumentName, new OpponentResponds("Those both make sense to me.", OpponentExpression.Bored), new CrowdResponds(CrowdExpression.NoComment));
        }
    }
}

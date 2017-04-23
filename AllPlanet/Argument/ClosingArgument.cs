using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument.Concrete
{
    public class ClosingArgument
    {
        public List<ClosingChoice> Choices { get; }

        public ClosingArgument(params ClosingChoice[] choices)
        {
            Choices = choices.ToList();
        }
    }
}

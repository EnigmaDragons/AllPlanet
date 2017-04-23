using System.Collections.Generic;
using System.Linq;

namespace AllPlanet.Argument
{
    public class ClosingChoice
    {
        public List<ClosingOption> Options { get; }

        public ClosingChoice(params ClosingOption[] options)
        {
            Options = options.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPlanet.Refute
{
    public class ArgumentPoint
    {
        public Statement[] Statements;

        public ArgumentPoint(Statement[] statement)
        {
            Statements = statement;
        }
    }
}

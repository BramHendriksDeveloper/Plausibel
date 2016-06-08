using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Parser
{
    public interface IParser
    {
        void SetCircuitName(string Name);

        Dictionary<string, string> GetInitialization();

        Dictionary<string, Operator.BaseOperator> DecorateOperators(Dictionary<string, Operator.BaseOperator> Operators);

        void StopParsing();
    }
}

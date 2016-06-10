using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Parser
{
    public interface IParser
    {
        /// <summary>
        /// Set the name of the circuit. This could open the connection to the source too.
        /// </summary>
        /// <param name="Name"></param>
        void SetCircuitName(string Name);

        /// <summary>
        /// Return a list with the definition of all operators
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetInitialization();

        /// <summary>
        /// Add the underlaying structure to the operators. The operators shoud be chained in the return value
        /// </summary>
        /// <param name="Operators"></param>
        /// <returns></returns>
        Dictionary<string, Operator.BaseOperator> DecorateOperators(Dictionary<string, Operator.BaseOperator> Operators);

        /// <summary>
        /// Close the connection to the operator source
        /// </summary>
        void StopParsing();
    }
}

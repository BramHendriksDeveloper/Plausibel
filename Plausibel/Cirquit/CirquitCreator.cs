using Plausibel.Operator;
using System.Collections.Generic;
using System.Linq;
using Plausibel.Parser;

namespace Plausibel.Cirquit
{
    public class CirquitCreator
    {
        private OperatorFactory _Factory;
        private IParser _Parser;

        /// <summary>
        /// Construct the circuitCreator by setting the circuit source
        /// </summary>
        /// <param name="Parser"></param>
        public CirquitCreator(IParser Parser)
        {
            _Factory = new OperatorFactory();
            _Parser = Parser;
        }

        /// <summary>
        /// Create a circuit by reading a specified source
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Cirquit GetCirquit(string fileName)
        {
            _Parser.SetCircuitName(fileName);
            Dictionary<string, string> OperatorNames = _Parser.GetInitialization();
            Dictionary<string, BaseOperator> OperatorList = ResolveOperators(OperatorNames);
            OperatorList = _Parser.DecorateOperators(OperatorList);
            _Parser.StopParsing();

            return new Cirquit(OperatorList);
        }

        /// <summary>
        /// Resolve a complete list of operators
        /// </summary>
        /// <param name="Operators"></param>
        /// <returns></returns>
        private Dictionary<string, BaseOperator> ResolveOperators(Dictionary<string, string> Operators)
        {
            return Operators.ToDictionary(v => v.Key, v => ResolveOperator(v.Value, v.Key));
        }

        /// <summary>
        /// Resolve a single operator
        /// </summary>
        /// <param name="OperatorType"></param>
        /// <param name="OperatorName"></param>
        /// <returns></returns>
        private BaseOperator ResolveOperator(string OperatorType, string OperatorName)
        {
            return _Factory.GetOperatorByName(OperatorType, OperatorName);
        }
    }
}

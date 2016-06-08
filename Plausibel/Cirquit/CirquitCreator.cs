using Plausibel.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plausibel.Parser;

namespace Plausibel.Cirquit
{
    public class CirquitCreator
    {
        private OperatorFactory _Factory;
        private IParser _Parser;

        public CirquitCreator(IParser Parser)
        {
            _Factory = new OperatorFactory();
            _Parser = Parser;
        }

        public Cirquit GetCirquit(string fileName)
        {
            _Parser.SetCircuitName(fileName);
            Dictionary<string, string> OperatorNames = _Parser.GetInitialization();
            Dictionary<string, BaseOperator> OperatorList = ResolveOperators(OperatorNames);
            OperatorList = _Parser.DecorateOperators(OperatorList);
            _Parser.StopParsing();

            return new Cirquit(OperatorList);
        }


        private Dictionary<string, BaseOperator> ResolveOperators(Dictionary<string, string> Operators)
        {
            return Operators.ToDictionary(v => v.Key, v => ResolveOperator(v.Value, v.Key));
        }

        private BaseOperator ResolveOperator(string OperatorType, string OperatorName)
        {
            return _Factory.GetOperatorByName(OperatorType, OperatorName);
        }
    }
}

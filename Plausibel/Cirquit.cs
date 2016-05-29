using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plausibel.Operator;

namespace Plausibel
{
    public class Cirquit
    {
        private Dictionary<String, BaseOperator> _Operators;

        public Cirquit(Dictionary<String, BaseOperator> operators)
        {
            _Operators = operators;
        }

        public bool Emulate(bool inputOne, bool inputTwo, bool Cin)
        {
            Set("A", inputOne);
            Set("B", inputTwo);
            Set("Cin", Cin);

            return Get("S");
        }

        public void Set(string operatorName, bool value)
        {
            if(_Operators.ContainsKey(operatorName) && _Operators[operatorName] is InputOperator && !_Operators[operatorName].IsFull())
            {
                _Operators[operatorName].SetValue(value);
            } else
            {
                System.Console.WriteLine("This operator is not an input operator or has already been set.");
            }
        }

        public bool Get(string operatorName)
        {
            if (!_Operators.ContainsKey(operatorName) || !(_Operators[operatorName] is ProbeOperator))
            {
                System.Console.WriteLine("This operator is not an probe operator.");
                return false;
            }

            ProbeOperator op = (ProbeOperator) _Operators[operatorName];
            if(!op.IsFull())
            {
                System.Console.WriteLine("This operator has no value yet.");
            }

            return op.GetValue();
        }
    }
}

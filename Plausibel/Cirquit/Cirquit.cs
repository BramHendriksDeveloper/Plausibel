using System;
using System.Collections.Generic;
using System.Linq;
using Plausibel.Operator;

namespace Plausibel.Cirquit
{
    public class Cirquit
    {
        private Dictionary<string, BaseOperator> _Operators;
        private Dictionary<string, InputOperator> _InputOperators = new Dictionary<string, InputOperator>();
        private Dictionary<string, ProbeOperator> _OutputOperators = new Dictionary<string, ProbeOperator>();

        public Cirquit(Dictionary<string, BaseOperator> allOperators)
        {
            _Operators = allOperators;

            foreach (KeyValuePair<string, BaseOperator> item in allOperators) {
                if(item.Value is InputOperator)
                {
                    _InputOperators.Add(item.Key, (InputOperator) item.Value);
                } else if (item.Value is ProbeOperator)
                {
                    _OutputOperators.Add(item.Key, (ProbeOperator) item.Value);
                }
            }
        }

        public List<InputOperator> GetInputOperators()
        {
            return _InputOperators.Values.ToList();
        }

        public Dictionary<string, bool> Emulate(Dictionary<string, bool> values)
        {
            foreach(KeyValuePair<string, bool> value in values)
            {
                Set(value.Key, value.Value);
            }

            return _OutputOperators.ToDictionary(v => v.Value.GetName(), v => v.Value.GetValue());
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

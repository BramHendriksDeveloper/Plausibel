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

        /// <summary>
        /// Get a list with all input operators
        /// </summary>
        /// <returns></returns>
        public List<InputOperator> GetInputOperators()
        {
            return _InputOperators.Values.ToList();
        }

        /// <summary>
        /// Emulate a circuit with given inputs
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Dictionary<string, Boolean> Emulate(Dictionary<string, Boolean> values)
        {
            foreach(KeyValuePair<string, Boolean> value in values)
            {
                Set(value.Key, value.Value, true);
            }

            return _OutputOperators.ToDictionary(v => v.Value.GetName(), v => v.Value.GetValue());
        }

        /// <summary>
        /// Get the emulation speed
        /// </summary>
        /// <returns></returns>
        public double GetEmulationSpeed()
        {
            double longest = 0;

            foreach(KeyValuePair<string, ProbeOperator> value in _OutputOperators)
            {
                double time = value.Value.GetDelay();
                if(time > longest)
                {
                    longest = time;
                }
            }

            return longest;
        }

        /// <summary>
        /// Set a single operator's value
        /// </summary>
        /// <param name="operatorName"></param>
        /// <param name="value"></param>
        /// <param name="showProcess"></param>
        public void Set(string operatorName, Boolean value, Boolean showProcess)
        {
            if(_Operators.ContainsKey(operatorName) && _Operators[operatorName] is InputOperator && !_Operators[operatorName].IsFull())
            {
                _Operators[operatorName].SetValue(value, showProcess);
            } else
            {
                System.Console.WriteLine("This operator is not an input operator or has already been set.");
            }
        }

        /// <summary>
        /// Get the value of a single operator
        /// </summary>
        /// <param name="operatorName"></param>
        /// <returns></returns>
        public Boolean Get(string operatorName)
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

        /// <summary>
        /// Reset the circuit
        /// </summary>
        public void Reset()
        {
            foreach (KeyValuePair<string, BaseOperator> item in _Operators)
            {
                item.Value.Reset();
            }
        }

        /// <summary>
        /// Validate the circuit
        /// </summary>
        /// <returns></returns>
        public Boolean validate()
        {
            Dictionary<string, Boolean> allInput = new Dictionary<string, Boolean>();

            // set all input operators to true
            foreach (InputOperator io in GetInputOperators())
            {
                io.SetValue(true);
            }

            // check if all operators have been used
            foreach (KeyValuePair<string, BaseOperator> item in _Operators)
            {
                if(item.Value.IsFull() == false)
                {
                    System.Console.WriteLine("Operator " + item.Key + " is not completed");
                    Reset();
                    return false;
                }
            }


            System.Console.WriteLine("Circuit was validated succesfully.");
            System.Console.WriteLine("______________________________________________");
            Reset();
            return true;
        }
    }
}

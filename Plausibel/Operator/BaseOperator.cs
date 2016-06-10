using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    abstract public class BaseOperator
    {
        public abstract double Delay
        {
            get;
        }

        /// <summary>
        /// Keep track of the total delay time
        /// </summary>
        protected double _TotalDelay = 0;
        
        /// <summary>
        /// The name of the node
        /// </summary>
        private String _Name = null;

        /// <summary>
        /// A list with the following nodes
        /// </summary>
        private List<BaseOperator> _NextOperators = new List<BaseOperator>();

        /// <summary>
        /// Boolean to indicate whether the operator has been used or not. The value will become true when the first input arrives
        /// </summary>
        protected Boolean _IsUsed = false;

        /// <summary>
        /// Boolean to indicate whether the operator has received all required inputs
        /// </summary>
        protected Boolean _IsFull = false;

        protected BaseOperator(String name)
        {
            _Name = name;
        }

        /// <summary>
        /// Add an operator to the list of next operators
        /// </summary>
        /// <param name="next"></param>
        public void SetNextOperator(BaseOperator next)
        {
            _NextOperators.Add(next);
        }

        /// <summary>
        /// Continue execution, proceed to the next operators
        /// </summary>
        /// <param name="output">The output of this node</param>
        /// <param name="showProcess">Whether or not to print the process in the console</param>
        virtual public void Continue(Boolean output, Boolean showProcess)
        {
            foreach (BaseOperator next in _NextOperators)
            {
                if(showProcess == true)
                {
                    System.Console.WriteLine("Nav from " + _Name + " to " + next.GetName() + " with value: " + (output ? "1" : "0"));
                }
                next.SetDelay(_TotalDelay + Delay);
                next.SetValue(output, showProcess);
            }
        }

        /// <summary>
        /// Check whether the operator has been used
        /// </summary>
        /// <returns></returns>
        public Boolean IsUsed()
        {
            return _IsUsed;
        }

        /// <summary>
        /// Check whether or not the operator has all its inputs
        /// </summary>
        /// <returns></returns>
        public Boolean IsFull()
        {
            return _IsFull;
        }

        /// <summary>
        /// Get the name of the operator
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return _Name;
        }

        /// <summary>
        /// Reset the operator
        /// </summary>
        virtual public void Reset()
        {
            _IsFull = false;
            _IsUsed = false;
            _TotalDelay = 0;
        }

        /// <summary>
        /// Set the TOTAL delay for the operator in the circuit
        /// </summary>
        /// <param name="delay"></param>
        protected void SetDelay(double delay)
        {
            _TotalDelay = delay;
        }

        /// <summary>
        /// Get the total delay of the operator in the circuit including the delay of the operator itself
        /// </summary>
        /// <returns></returns>
        public double GetDelay()
        {
            return _TotalDelay + Delay;
        }

        /// <summary>
        /// Abstract method to execute the operator
        /// </summary>
        /// <returns></returns>
        abstract public Boolean PerformOperation();

        /// <summary>
        /// Set the input of this operator
        /// </summary>
        /// <param name="input"></param>
        /// <param name="showProcess"></param>
        abstract public void SetValue(Boolean input, Boolean showProcess);

        /// <summary>
        /// Set the input of this operator without printing the process
        /// </summary>
        /// <param name="input"></param>
        public void SetValue(Boolean input)
        {
            SetValue(input, false);
        }

        
    }
}

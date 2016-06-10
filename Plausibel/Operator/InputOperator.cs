using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class InputOperator : SingleInputOperator
    {
        private static double _Delay = 0.3;

        public override double Delay
        {
            get
            {
                return InputOperator._Delay;
            }
        }

        public InputOperator(String name) : base(name) { }

        /// <summary>
        /// An input operator does not perform any modification to the value, so just return the original value
        /// </summary>
        /// <returns></returns>
        public override bool PerformOperation()
        {
            return _Value;
        }
    }
}

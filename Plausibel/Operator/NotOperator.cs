using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class NotOperator : SingleInputOperator
    {
        private static double _Delay = 0.3;

        public override double Delay
        {
            get
            {
                return NotOperator._Delay;
            }
        }

        public NotOperator(String name) : base(name) { }

        /// <summary>
        /// Perform the NOT operation !A
        /// </summary>
        /// <returns></returns>
        public override bool PerformOperation()
        {
            return !_Value;
        }
    }
}

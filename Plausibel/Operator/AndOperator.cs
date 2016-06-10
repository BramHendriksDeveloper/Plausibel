using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class AndOperator : DualInputOperator
    {

        public AndOperator(String name) : base(name) { }

        private static double _Delay = 0.3;

        public override double Delay
        {
            get
            {
                return AndOperator._Delay;
            }
        }
        
        /// <summary>
        /// Perform the and operation A ^ B
        /// </summary>
        /// <returns>bool</returns>
        public override bool PerformOperation()
        {
            return _Value[0] && _Value[1];
        }
    }
}

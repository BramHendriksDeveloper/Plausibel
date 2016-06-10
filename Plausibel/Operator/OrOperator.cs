using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class OrOperator : DualInputOperator
    {
        private static double _Delay = 0.3;

        public override double Delay
        {
            get
            {
                return OrOperator._Delay;
            }
        }

        public OrOperator(String name) : base(name) { }

        /// <summary>
        /// Perform the OR operation A v B
        /// </summary>
        /// <returns></returns>
        public override bool PerformOperation()
        {
            return _Value[0] || _Value[1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public class XorOperator : DualInputOperator
    {
        public XorOperator(String name) : base(name) { }

        public override bool PerformOperation()
        {
            return (!_Value[0] && _Value[1]) || (_Value[0] && !_Value[1]);
        }
    }
}

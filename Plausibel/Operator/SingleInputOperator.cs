using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    abstract public class SingleInputOperator : BaseOperator
    {

        protected Boolean _Value = false;

        public SingleInputOperator(String name) : base(name) { }
        

        public override void SetValue(bool input, Boolean showProcess)
        {
            _IsUsed = true;
            _IsFull = true;
            _Value = input;
            Boolean output = PerformOperation();
            Continue(output, showProcess);
        }

        public override void Reset()
        {
            base.Reset();
            _Value = false;
        }
    }
}

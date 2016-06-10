using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Operator
{
    public abstract class DualInputOperator : BaseOperator
    {
        protected Boolean[] _Value = new Boolean[2];
        private int _Iterator = 0;

         public DualInputOperator(String name) : base(name) { }

        /// <summary>
        /// Set the value of the dual input operator.
        /// After setting the second value, the process will continue
        /// </summary>
        /// <param name="input"></param>
        /// <param name="showProcess"></param>
        public override void SetValue(Boolean input, Boolean showProcess)
        {
            _Value[_Iterator++] = input;

            if(_Iterator >= _Value.Length)
            {
                _IsFull = true;

                Boolean output = PerformOperation();
                Continue(output, showProcess);
            }

            _IsUsed = true;
        }

        /// <summary>
        /// Reset both values of the dual input operator
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            _Value = new Boolean[2];
            _Iterator = 0;
        }
    }
}
